using BirdyBird.InputSystem;
using UnityEngine;

namespace BirdyBird
{
    [DefaultExecutionOrder(-1)]
    // To do:
    // Create a bootstrap scene and remove "[DefaultExecutionOrder(-1)]" attribute
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance
        {
            get;
            private set;
        } = null;

        [SerializeField]
        private InputActionContainer _inputContainer = null;
        public InputActionContainer InputContainer { get { return _inputContainer; } }

        private void Awake()
        {
            SetSingleton();
        }
        private void SetSingleton()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }
    }
}