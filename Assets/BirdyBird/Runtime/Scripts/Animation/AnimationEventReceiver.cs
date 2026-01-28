using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Animation
{
    internal class AnimationEventReceiver : MonoBehaviour, IAnimationEventReceiver
    {
        [SerializeField]
        private List<AnimationEvent> _events = new();

        public void OnAnimationEventTriggered(string name)
        {
            AnimationEvent matchingEvent = _events.Find(ev => ev.eventName == name);
            matchingEvent.OnAnimationEvent?.Invoke();
        }

    }
}
