using UnityEngine;

namespace BirdyBird.Environment
{
    public class ParallaxSystem : MonoBehaviour
    {
        [SerializeField]
        private ConveyorLoop[] _conveyorLoops = null;
        private bool _canMove = false;

        private void Awake() => _canMove = true;

        private void Update()
        {
            if (!_canMove)
                return;
            for (int i = 0; i < _conveyorLoops.Length; i++)
                _conveyorLoops[i].UpdateConveyorLoop();
        }

        public void StopParallax() => _canMove = false;
        public void StartParallax() => _canMove = true;

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