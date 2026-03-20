using BirdyBird.UI.Start;
using UnityEngine;

namespace BirdyBird.DummyPlayer
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class DummyPlayerController : MonoBehaviour
    {
        private Animator _animator = null;

        private void Awake() => _animator = GetComponent<Animator>();
        private void Start()
        {
            _animator.speed = 3.0f;
        }

        public void SetAnimatorController(RuntimeAnimatorController animatorController)
            => _animator.runtimeAnimatorController = animatorController;

    }
}