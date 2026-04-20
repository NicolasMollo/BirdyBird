using BirdyBird.AI;
using BirdyBird.Audio;
using BirdyBird.Data;
using BirdyBird.Environment;
using BirdyBird.Events;
using BirdyBird.InputSystem;
using BirdyBird.Level.UI;
using BirdyBird.Player;
using BirdyBird.Score;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace BirdyBird.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private Fsm _fsm = null;
        [SerializeField]
        private PlayerController _player = null;
        [SerializeField]
        private ParallaxSystem _parallaxSystem = null;
        [SerializeField]
        private ScoreManager _scoreManager = null;
        [SerializeField]
        private LevelSceneUI _UI = null;
        [SerializeField]
        private LevelConfigurationData _configurationData = null;

        private InputActionContainer _input = null;
        private AudioManager _audioManager = null;

        private void Awake()
        {
            SetUpDependencies();
            SetUpInput();
        }
        private void Start()
        {
            AddListeners();
            _fsm.Init();
            _player.Init(_input, _configurationData.playerViewData.AnimatorController, _audioManager);
            _parallaxSystem.Init(_configurationData.parallaxViewData.SpriteList);
            _audioManager.PlayMusic(_configurationData.parallaxViewData.Clip);
            _UI.SetBackgroundScoreColor(_configurationData.parallaxViewData.ScoreBackgroundColor);
            _UI.SetTapHereTextColor(_configurationData.parallaxViewData.TextsColor);
            // BirdyBird.Save.SaveSystem.DeleteData();
        }
        private void SetUpDependencies()
        {
            GameManager gm = GameManager.Instance;
            _input = gm.InputContainer;
            _audioManager = gm.AudioManager;
        }
        private void SetUpInput()
        {
            _input.InputActions.UI.Enable();
        }

        private void OnDestroy()
        {
            RemoveListeners();
            _input.InputActions.UI.Disable();
        }

        private void AddListeners()
        {
            _player.HealthModule.OnDeath += OnPlayerDeath;
            _UI.SubOnReloadButtonClick(OnReloadButtonClick);
            _UI.SubOnExitButtonClick(OnExitButtonClick);
            _scoreManager.OnScoreChanged += OnScoreChanged;
            GameEventBus.OnGameIdleStateEnter += OnGameIdleStateEnter;
            GameEventBus.OnGameIdleStateExit += OnGameIdleStateExit;
        }
        private void RemoveListeners()
        {
            GameEventBus.OnGameIdleStateExit -= OnGameIdleStateExit;
            GameEventBus.OnGameIdleStateEnter -= OnGameIdleStateEnter;
            _scoreManager.OnScoreChanged -= OnScoreChanged;
            _UI.UnsubFromOnReloadButtonClick(OnReloadButtonClick);
            _UI.UnsubFromOnExitButtonClick(OnExitButtonClick);
            _player.HealthModule.OnDeath -= OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            _fsm.ChangeState<GameOverState>();
        }
        private void OnReloadButtonClick()
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
            _audioManager.PlaySfx(SfxType.ConfirmButton);
        }
        private void OnExitButtonClick()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            _audioManager.PlaySfx(SfxType.BackButton);
        }

        private void OnGameIdleStateEnter()
        {
            _input.InputActions.UI.Confirm.performed += OnConfirmInputPerformed;
        }

        private void OnGameIdleStateExit()
        {
            _input.InputActions.UI.Confirm.performed -= OnConfirmInputPerformed;
        }
        private void OnConfirmInputPerformed(InputAction.CallbackContext context)
        {
            _fsm.ChangeState<GameState>();
        }

        private void OnScoreChanged(int score)
        {
            _audioManager.PlaySfx(SfxType.Score);
        }

    }
}