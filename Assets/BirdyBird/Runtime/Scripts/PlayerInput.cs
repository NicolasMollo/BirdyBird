using System;
using UnityEngine.InputSystem;

namespace BirdyBird.Player
{
    internal class PlayerInput
    {
        private InputSystem_Actions _inputActions = null;

        internal PlayerInput()
        {
            _inputActions = new InputSystem_Actions();
            _inputActions.Player.Enable();
        }

        internal void Disable()
        {
            _inputActions.Player.Disable();
        }

        internal void SubscribeOnMove(Action<InputAction.CallbackContext> callback)
        {
            _inputActions.Player.Move.performed += callback;
        }
        internal void UnsubscribeFromMove(Action<InputAction.CallbackContext> callback)
        {
            _inputActions.Player.Move.performed -= callback;
        }

    }

}