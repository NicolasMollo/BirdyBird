using UnityEngine;

namespace BirdyBird.UI.Start
{
    public abstract class ViewDataContainer<T> : MonoBehaviour where T : BaseViewData
    {
        [SerializeField]
        private T _viewData = null;
        public T ViewData { get { return _viewData; } }
    }
}