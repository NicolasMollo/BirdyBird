using BirdyBird.AI;
using BirdyBird.Data;
using BirdyBird.Environment;
using BirdyBird.Events;
using BirdyBird.InputSystem;
using BirdyBird.Player;
using BirdyBird.UI;
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
        private UISystem _UI = null;
        [SerializeField]
        private LevelConfigurationData _viewConfigurationData = null;

        private InputActionContainer _input = null;

        private void Awake()
        {
            SetUpDependencies();
            SetUpInput();
        }
        private void Start()
        {
            AddListeners();
            _fsm.Init();
            _player.Init(_input, _viewConfigurationData.playerViewData.AnimatorController);
            _parallaxSystem.Init(_viewConfigurationData.parallaxViewData.SpriteList);
            _UI.SetBackgroundScoreColor(_viewConfigurationData.parallaxViewData.ScoreBackgroundColor);
            _UI.SetTapHereTextColor(_viewConfigurationData.parallaxViewData.TextsColor);
        }
        private void SetUpDependencies()
        {
            GameManager gm = GameManager.Instance;
            _input = gm.InputContainer;
        }
        private void SetUpInput()
        {
            _input.InputActions.UI.Enable();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                // _parallax.StopParallax();
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                // _parallax.IncreaseSpeed(1.5f);
            }
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
            GameEventBus.OnGameIdleStateEnter += OnGameIdleStateEnter;
            GameEventBus.OnGameIdleStateExit += OnGameIdleStateExit;
        }
        private void RemoveListeners()
        {
            GameEventBus.OnGameIdleStateExit -= OnGameIdleStateExit;
            GameEventBus.OnGameIdleStateEnter -= OnGameIdleStateEnter;
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
        }
        private void OnExitButtonClick() => SceneManager.LoadScene(1, LoadSceneMode.Single);

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


    }
}