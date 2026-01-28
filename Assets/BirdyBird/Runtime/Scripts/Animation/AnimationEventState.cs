using System;
using UnityEngine;

namespace BirdyBird.Animation
{
    public class AnimationEventState : StateMachineBehaviour
    {
        [SerializeField]
        private string _eventName = string.Empty;
        [SerializeField]
        [Range(0f, 1f)]
        private float _triggerTime = 0f;
        private bool _hasTriggered = false;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _hasTriggered = false;
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float currentTime = stateInfo.normalizedTime % 1;
            if (!_hasTriggered && currentTime >= _triggerTime)
            {
                _hasTriggered = true;
                NotifyReceiver(animator);
            }
        }

        private void NotifyReceiver(Animator animator)
        {
            IAnimationEventReceiver receiver = animator.GetComponent<IAnimationEventReceiver>();
            if (receiver != null)
            {
                receiver.OnAnimationEventTriggered(_eventName);
            }
        }

    }
}