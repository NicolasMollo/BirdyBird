using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BirdyBird.UI.Loading
{
    internal class LoadingView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _loadingText = null;
        [SerializeField]
        private Image _loadingBar = null;
        [SerializeField]
        private Image _loadingBarBackground = null;
        [SerializeField]
        private TextMeshProUGUI _loadingPercentangeText = null;

        internal float LoadingBarBackgroundSizeX { get { return _loadingBarBackground.rectTransform.sizeDelta.x; } }

        internal void SetLoadingText(string text) => _loadingText.text = text;
        internal void SetLoadingPercentageText(string text) => _loadingPercentangeText.text = $"{text} %";

        internal void UpdateLoadingBar(float sizeDeltaX)
        {
            _loadingBar.rectTransform.sizeDelta = new Vector2(
                sizeDeltaX,
                _loadingBar.rectTransform.sizeDelta.y
                );
        }
    }
}