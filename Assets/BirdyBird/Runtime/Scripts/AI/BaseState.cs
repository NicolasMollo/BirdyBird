using UnityEngine;

namespace BirdyBird.AI
{
    public abstract class BaseState : MonoBehaviour
    {
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }
        public virtual void OnStateUpdate() { }
    }
}