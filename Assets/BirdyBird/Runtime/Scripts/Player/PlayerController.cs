using BirdyBird.Modules;
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


        private void Awake()
        {
            _input = new PlayerInput();
            _movement = GetComponent<PlayerMovement>();
            _canMove = false;
            _animation = GetComponent<PlayerAnimation>();
            _healthModule = GetComponent<HealthModule>();
        }

        private void OnEnable()
        {
            AddListeners();
        }
        private void OnDisable()
        {
            RemoveListeners();
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
            _input.SubscribeOnMove(OnMoveInputPerformed);
            _healthModule.OnDeath += OnDeath;
        }
        private void RemoveListeners()
        {
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

    }
}