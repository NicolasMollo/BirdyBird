using UnityEngine;

namespace BirdyBird.Start
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class PreviewPlayerController : MonoBehaviour
    {
        private Animator _animator = null;
        [SerializeField]
        private float _animatorSpeed = 0f;

        private void Awake() => _animator = GetComponent<Animator>();
        private void Start() => _animator.speed = _animatorSpeed;

        public void SetAnimatorController(RuntimeAnimatorController animatorController) => _animator.runtimeAnimatorController = animatorController;
    }
}