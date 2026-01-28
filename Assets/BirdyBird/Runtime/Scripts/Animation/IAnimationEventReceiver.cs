using System;

namespace BirdyBird.Animation
{
    internal interface IAnimationEventReceiver
    {
        void OnAnimationEventTriggered(string name);
    }
}