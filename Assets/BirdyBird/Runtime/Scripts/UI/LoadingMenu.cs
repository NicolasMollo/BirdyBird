using UnityEngine;
using UnityEngine.SceneManagement;

namespace BirdyBird.UI.Loading
{
    [RequireComponent(typeof(LoadingModel), typeof(LoadingView))]
    public class LoadingMenu : MonoBehaviour
    {
        private LoadingModel _model = null;
        private LoadingView _view = null;

        private void Awake()
        {
            _model = GetComponent<LoadingModel>();
            _view = GetComponent<LoadingView>();
        }
        private void OnEnable() => _model.OnDelayReached += OnDelayReached;
        private void OnDisable() => _model.OnDelayReached -= OnDelayReached;
        private void OnDelayReached() => SceneManager.LoadScene(0, LoadSceneMode.Single);

        private void Update()
        {
            float sizeDeltaX = _model.TimePercentage * _view.LoadingBarBackgroundSizeX;
            int loadingPercentage = (int)(_model.TimePercentage * 100f);
            _view.UpdateLoadingBar(sizeDeltaX);
            _view.SetLoadingPercentageText(loadingPercentage.ToString());
        }
    }
}