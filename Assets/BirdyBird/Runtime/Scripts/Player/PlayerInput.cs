using BirdyBird.InputSystem;
using System;
using UnityEngine.InputSystem;

namespace BirdyBird.Player
{
    internal class PlayerInput
    {
        private InputSystem_Actions.PlayerActions _playerActionMap = default;

        internal PlayerInput(InputActionContainer inputContainer)
        {
            _playerActionMap = inputContainer.InputActions.Player;
            _playerActionMap.Enable();
        }

        internal void Disable() => _playerActionMap.Disable();
        internal void Enable() => _playerActionMap.Enable();

        internal void SubscribeOnMove(Action<InputAction.CallbackContext> callback) => _playerActionMap.Move.performed += callback;
        internal void UnsubscribeFromMove(Action<InputAction.CallbackContext> callback) => _playerActionMap.Move.performed -= callback;
    }
}