using System;

namespace BirdyBird.Events
{
    public static class GameEventBus
    {
        public static event Action OnScoreTriggerCollision = null;
        public static void CallOnScoreTriggerCollision()
        {
            OnScoreTriggerCollision?.Invoke();
        }
    }
}