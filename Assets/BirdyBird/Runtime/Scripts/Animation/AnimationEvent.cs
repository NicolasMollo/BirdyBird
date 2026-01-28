using System;
using UnityEngine.Events;

namespace BirdyBird.Animation
{
    [Serializable]
    internal class AnimationEvent
    {
        public string eventName = string.Empty;
        public UnityEvent OnAnimationEvent = null;
    }
}