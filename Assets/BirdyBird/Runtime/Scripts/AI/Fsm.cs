using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.AI
{
    public class Fsm : MonoBehaviour
    {
        [SerializeField]
        private List<BaseState> _states = null;
        [SerializeField]
        private BaseState _startState = null;
        private BaseState _currentState = null;

        public void Init()
        {
            _currentState = _startState;
            _currentState.OnStateEnter();
        }
        public void ChangeState<T>() where T : BaseState
        {
            _currentState?.OnStateExit();
            BaseState nextState = GetState<T>();
            if (nextState == null)
            {
                Debug.LogError($"State {typeof(T).Name} not found", this);
                return;
            }
            _currentState = nextState;
            _currentState.OnStateEnter();
        }
        private T GetState<T>() where T : BaseState
        {
            foreach (BaseState state in _states)
            {
                if (state is T typedState)
                    return typedState;
            }
            return null;
        }

    }
}