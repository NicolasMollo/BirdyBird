using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BirdyBird.Start.UI
{
    public abstract class SelectionBlock<T> : MonoBehaviour where T : BaseViewData
    {
        [SerializeField]
        private Button _leftButton = null;
        [SerializeField]
        private Button _rightButton = null;
        [SerializeField]
        private List<ViewDataContainer<T>> _viewDataList = null;

        private ViewDataContainer<T> _selectedViewData = null;
        public Action<T, int> OnSelectViewData = null;
        public Action OnLeftButtonClick = null;
        public Action OnRightButtonClick = null;

        public void Init(int selectedViewDataIndex = 0)
        {
            foreach (ViewDataContainer<T> viewData in _viewDataList)
                viewData.gameObject.SetActive(false);
            SetSelectedViewData(selectedViewDataIndex);
        }

        private void OnEnable()
        {
            _leftButton.onClick.AddListener(CallOnLeftButtonClick);
            _leftButton.onClick.AddListener(SelectPreviousViewData);
            _rightButton.onClick.AddListener(CallOnRightButtonClick);
            _rightButton.onClick.AddListener(SelectNextViewData);
        }
        private void OnDisable()
        {
            _rightButton.onClick.RemoveAllListeners();
            _leftButton.onClick.RemoveAllListeners();
        }

        private void CallOnLeftButtonClick() => OnLeftButtonClick?.Invoke();
        private void CallOnRightButtonClick() => OnRightButtonClick?.Invoke();

        private void SelectNextViewData()
        {
            int index = _viewDataList.IndexOf(_selectedViewData);
            index++;
            if (index == _viewDataList.Count)
                index = 0;
            SetSelectedViewData(index);
        }
        private void SelectPreviousViewData()
        {
            int index = _viewDataList.IndexOf(_selectedViewData);
            index--;
            if (index < 0)
                index = _viewDataList.Count - 1;
            SetSelectedViewData(index);
        }
        private void SetSelectedViewData(int index)
        {
            if (_selectedViewData != null)
                _selectedViewData.gameObject.SetActive(false);
            _selectedViewData = _viewDataList[index];
            _selectedViewData.gameObject.SetActive(true);
            OnSelectViewData?.Invoke(_selectedViewData.ViewData, index);
        }

    }
}