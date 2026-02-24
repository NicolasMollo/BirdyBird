using BirdyBird.Events;

namespace BirdyBird.AI
{
    public class GameOverState : BaseState
    {
        public override void OnStateEnter() => GameEventBus.CallOnGameOverStateEnter();
        public override void OnStateExit() => GameEventBus.CallOnGameOverStateExit();
    }
}