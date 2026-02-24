using BirdyBird.Events;

namespace BirdyBird.AI
{
    public class GameState : BaseState
    {
        public override void OnStateEnter() => GameEventBus.CallOnGameStateEnter();
        public override void OnStateExit() => GameEventBus.CallOnGameStateExit();
    }
}