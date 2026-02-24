using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BirdyBird.UI
{
    internal class UI_GameOverMenu : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText = null;
        [SerializeField]
        private Button _reloadButton = null;

        internal void SetScoreText(string text) => _scoreText.text = text;
        internal void SubOnReloadButtonClick(UnityAction callback) => _reloadButton.onClick.AddListener(callback);
        internal void UnsubFromOnReloadButtonClick(UnityAction callback) => _reloadButton.onClick.RemoveListener(callback);
    }
}