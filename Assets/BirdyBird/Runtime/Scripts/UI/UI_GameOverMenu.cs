using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BirdyBird.Level.UI
{
    internal class UI_GameOverMenu : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText = null;
        [SerializeField]
        private TextMeshProUGUI _bestScoreText = null;
        [SerializeField]
        private Button _reloadButton = null;
        [SerializeField]
        private Button _exitButton = null;
        [SerializeField]
        private Image _trophyImage = null;

        private void Awake() => _trophyImage.gameObject.SetActive(false);

        internal void ActivateTrophyImage() => _trophyImage.gameObject.SetActive(true);
        internal void SetScoreText(string text) => _scoreText.text = text;
        internal void SetBestScoreText(string text) => _bestScoreText.text = text;
        internal void SubOnReloadButtonClick(UnityAction callback) => _reloadButton.onClick.AddListener(callback);
        internal void UnsubFromOnReloadButtonClick(UnityAction callback) => _reloadButton.onClick.RemoveListener(callback);
        internal void SubOnExitButtonClick(UnityAction callback) => _exitButton.onClick.AddListener(callback);
        internal void UnsubFromOnExitButtonClick(UnityAction callback) => _exitButton.onClick.RemoveListener(callback);
    }
}