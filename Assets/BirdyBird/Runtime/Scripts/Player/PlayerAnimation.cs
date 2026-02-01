using BirdyBird.Animation;
using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    internal class PlayerAnimation : MonoBehaviour, IAnimationEventReceiver
    {
        private Animator _animator = null;
        private int _flyStateNameHash = 0;
        [SerializeField]
        private string _flyStateName = string.Empty;
        [SerializeField]
        private float _flySpeed = 0f;
        [SerializeField]
        private List<Animation.AnimationEvent> _events = new List<Animation.AnimationEvent>();


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _flyStateNameHash = Animator.StringToHash(_flyStateName);
            SetAnimatorSpeed(_flySpeed);
        }

        public void OnAnimationEventTriggered(string name)
        {
            Animation.AnimationEvent animationEvent = _events.Find(ev => ev.eventName == name);
            animationEvent.OnAnimationEvent?.Invoke();
        }
        public void Fly() => _animator.Play(_flyStateNameHash);
        public void SetAnimatorSpeed(float speed) => _animator.speed = speed;

    }
}