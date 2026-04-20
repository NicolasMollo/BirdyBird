using System;

namespace BirdyBird.Events
{
    public static class GameEventBus
    {
        public static event Action OnScoreTriggerCollision = null;
        public static void CallOnScoreTriggerCollision() => OnScoreTriggerCollision?.Invoke();

        public static event Action OnGameOverStateEnter = null;
        public static event Action OnGameOverStateExit = null;
        public static void CallOnGameOverStateEnter() => OnGameOverStateEnter?.Invoke();
        public static void CallOnGameOverStateExit() => OnGameOverStateExit?.Invoke();

        public static event Action OnGameIdleStateEnter = null;
        public static event Action OnGameIdleStateExit = null;
        public static void CallOnGameIdleStateEnter() => OnGameIdleStateEnter?.Invoke();
        public static void CallOnGameIdleStateExit() => OnGameIdleStateExit?.Invoke();

        public static event Action OnGameStateEnter = null;
        public static event Action OnGameStateExit = null;
        public static void CallOnGameStateEnter() => OnGameStateEnter?.Invoke();
        public static void CallOnGameStateExit () => OnGameStateExit?.Invoke();
    }
}