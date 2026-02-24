using BirdyBird.Events;

namespace BirdyBird.AI
{
    public class GameIdleState : BaseState
    {
        public override void OnStateEnter() => GameEventBus.CallOnGameIdleStateEnter();
        public override void OnStateExit() => GameEventBus.CallOnGameIdleStateExit();
    }
}