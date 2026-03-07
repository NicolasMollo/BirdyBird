using UnityEngine;

namespace BirdyBird.InputSystem
{
    [DefaultExecutionOrder(-1)]
    // To do:
    // Create a bootstrap scene and remove "[DefaultExecutionOrder(-1)]" attribute
    public class InputActionContainer : MonoBehaviour
    {
        private InputSystem_Actions _inputActions = null;
        public InputSystem_Actions InputActions { get { return _inputActions; } }

        private void Awake() => _inputActions = new InputSystem_Actions();
    }
}