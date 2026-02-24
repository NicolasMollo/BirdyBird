using BirdyBird.Events;
using BirdyBird.Score;
using BirdyBird.Toolkit;
using UnityEngine;
using UnityEngine.Events;

namespace BirdyBird.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField]
        private ScoreManager _scoreManager = null;
        [SerializeField]
        private UI_Score _score = null;
        [SerializeField]
        private UI_GameOverMenu _gameOverMenu = null;
        [SerializeField]
        private FadeableItem _panel = null;

        private void Start()
        {
            _gameOverMenu.gameObject.SetActive(false);
        }
        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();

        private void AddListeners()
        {
            _scoreManager.OnScoreChanged += OnScoreChanged;
            GameEventBus.OnGameOverStateEnter += OnGameOverStateEnter;
        }
        private void RemoveListeners()
        {
            _scoreManager.OnScoreChanged -= OnScoreChanged;
            GameEventBus.OnGameOverStateEnter -= OnGameOverStateEnter;
        }

        private void OnScoreChanged(int score)
        {
            _score.SetScoreText(score.ToString());
        }
        private void OnGameOverStateEnter()
        {
            _score.FadeOutScore(HandleFadeblePanel);
        }
        private void HandleFadeblePanel()
        {
            _panel.FadeIn(HandleGameOverMenu);
        }
        private void HandleGameOverMenu()
        {
            _gameOverMenu.gameObject.SetActive(true);
            _gameOverMenu.SetScoreText(_scoreManager.Score.ToString());
        }
        public void SubOnReloadButtonClick(UnityAction callback) => _gameOverMenu.SubOnReloadButtonClick(callback);
        public void UnsubFromOnReloadButtonClick(UnityAction callback) => _gameOverMenu.UnsubFromOnReloadButtonClick(callback);
    }
}