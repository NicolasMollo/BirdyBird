using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BirdyBird.UI
{
    public class LoadingMenu : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _loadingText = null;
        [SerializeField]
        private Image _loadingBar = null;
        [SerializeField]
        private Image _loadingBarBackground = null;
        [SerializeField]
        private TextMeshProUGUI _loadingPercentangeText = null;
        [SerializeField, Range(0.1f, 10.0f)]
        private float _delay = 0f;
        private float _elapsedTime = 0f;
        public float ElapsedTime
        {
            get { return _elapsedTime; }
            set { _elapsedTime = Mathf.Clamp(value, 0, _delay); }
        }

        public void SetLoadingText(string text) => _loadingText.text = text;
        public void SetLoadingPercentageText(string text) => _loadingPercentangeText.text = $"{text} %";

        public void UpdateLoadingBar(float sizeDeltaX)
        {
            _loadingBar.rectTransform.sizeDelta = new Vector2(
                sizeDeltaX,
                _loadingBar.rectTransform.sizeDelta.y
                );
        }

        private void Update()
        {
            ElapsedTime += Time.deltaTime;
            float timePercentage = ElapsedTime / _delay;
            float sizeDeltaX = timePercentage * _loadingBarBackground.rectTransform.sizeDelta.x;
            UpdateLoadingBar(sizeDeltaX);
            int loadingPercentage = (int)(timePercentage * 100f);
            SetLoadingPercentageText(loadingPercentage.ToString());
            if (_elapsedTime >= _delay)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
        }

    }
}