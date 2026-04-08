using BirdyBird.InputSystem;
using BirdyBird.Save;
using UnityEngine;

namespace BirdyBird
{
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
            DontDestroyOnLoad(this);
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