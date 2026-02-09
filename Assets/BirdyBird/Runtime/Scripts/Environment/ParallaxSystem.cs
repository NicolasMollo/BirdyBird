using BirdyBird.Movement;
using UnityEngine;

namespace BirdyBird.Environment
{
    public class ParallaxSystem : MonoBehaviour
    {
        [SerializeField]
        private ConveyorLoop[] _conveyorLoops = null;
        private bool _canUpdate = false;

        private void Awake() => _canUpdate = true;

        private void Update()
        {
            if (!_canUpdate)
                return;
            for (int i = 0; i < _conveyorLoops.Length; i++)
                _conveyorLoops[i].UpdateConveyorLoop();
        }

        public void StopSystem() => _canUpdate = false;
        public void StartSystem() => _canUpdate = true;

        public void IncreaseSpeed(float multiplier)
        {
            for (int i = 0; i < _conveyorLoops.Length; i++)
                _conveyorLoops[i].IncreaseSpeed(multiplier);
        }
        public void SetDirection(DirectionType direction)
        {
            for (int i = 0; i < _conveyorLoops.Length; i++)
                _conveyorLoops[i].SetDirection(direction);
        }
    }
}