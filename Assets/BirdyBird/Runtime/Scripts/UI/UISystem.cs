using BirdyBird.Events;
using BirdyBird.Score;
using BirdyBird.Toolkit;
using TMPro;
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
        [SerializeField]
        private TextMeshProUGUI _tapHereText = null;

        private void Start()
        {
            _gameOverMenu.gameObject.SetActive(false);
        }
        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();

        private void AddListeners()
        {
            _scoreManager.OnScoreChanged += OnScoreChanged;
            GameEventBus.OnGameIdleStateEnter += OnGameIdleStateEnter;
            GameEventBus.OnGameStateEnter += OnGameStateEnter;
            GameEventBus.OnGameOverStateEnter += OnGameOverStateEnter;
        }
        private void RemoveListeners()
        {
            GameEventBus.OnGameOverStateEnter -= OnGameOverStateEnter;
            GameEventBus.OnGameStateEnter -= OnGameStateEnter;
            GameEventBus.OnGameIdleStateEnter -= OnGameIdleStateEnter;
            _scoreManager.OnScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            _score.SetScoreText(score.ToString());
        }
        private void OnGameOverStateEnter()
        {
            _score.FadeOutScore(HandleFadeblePanel);
        }
        private void OnGameStateEnter()
        {
            _tapHereText.gameObject.SetActive(false);
            _score.gameObject.SetActive(true);
        }
        private void OnGameIdleStateEnter()
        {
            _score.gameObject.SetActive(false);
            _tapHereText.gameObject.SetActive(true);
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