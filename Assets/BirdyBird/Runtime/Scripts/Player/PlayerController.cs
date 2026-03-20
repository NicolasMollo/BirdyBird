using BirdyBird.Events;
using BirdyBird.Health;
using BirdyBird.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BirdyBird.Player
{
   [RequireComponent
        (
        typeof(PlayerMovement), 
        typeof(PlayerAnimation),
        typeof(HealthModule)
        )]
    public class PlayerController : MonoBehaviour
    {
        private PlayerInput _input = null;
        private PlayerMovement _movement = null;
        private bool _canMove = false;
        private PlayerAnimation _animation = null;
        private HealthModule _healthModule = null;
        public HealthModule HealthModule { get { return _healthModule; } }

        public void Init(InputActionContainer inputContainer, RuntimeAnimatorController animatorController)
        {
            _input = new PlayerInput(inputContainer);
            _input.SubscribeOnMove(OnMoveInputPerformed);
            _input.Disable();
            _animation.SetAnimatorController(animatorController);
        }
        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _animation = GetComponent<PlayerAnimation>();
            _healthModule = GetComponent<HealthModule>();
            _canMove = false;
        }
        private void OnEnable()
        {
            AddListeners();
        }
        private void OnDisable()
        {
            RemoveListeners();
            _input.Disable();
        }

        private void FixedUpdate()
        {
            if (_canMove)
            {
                _movement.Move();
                _animation.Fly();
                _canMove = false;
            }
        }

        private void AddListeners()
        {
            _healthModule.OnDeath += OnDeath;
            GameEventBus.OnGameIdleStateEnter += OnGameIdleStateEnter;
            GameEventBus.OnGameStateEnter += OnGameStateEnter;
        }
        private void RemoveListeners()
        {
            GameEventBus.OnGameStateEnter -= OnGameStateEnter;
            GameEventBus.OnGameIdleStateEnter -= OnGameIdleStateEnter;
            _healthModule.OnDeath -= OnDeath;
            _input.UnsubscribeFromMove(OnMoveInputPerformed);
        }
        private void OnMoveInputPerformed(InputAction.CallbackContext context)
        {
            _canMove = true;
        }
        private void OnDeath()
        {
            _input.Disable();
        }

        private void OnGameIdleStateEnter()
        {
            // _input?.Disable();
            _movement.Disable();
        }
        private void OnGameStateEnter()
        {
            _input.Enable();
            _movement.Enable();
            _animation.Idle();
        }

    }
}