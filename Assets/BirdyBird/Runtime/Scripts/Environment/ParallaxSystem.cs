using BirdyBird.Events;
using BirdyBird.Movement;
using BirdyBird.Start.UI;
using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Environment
{
    public class ParallaxSystem : MonoBehaviour
    {
        [SerializeField]
        private ConveyorLoop[] _conveyorLoops = null;
        private bool _canUpdate = false;

        private void Awake() => _canUpdate = true;

        private void OnEnable() => GameEventBus.OnGameOverStateEnter += OnGameOverStateEnter;
        private void OnDisable() => GameEventBus.OnGameOverStateEnter -= OnGameOverStateEnter;

        private void Update()
        {
            if (!_canUpdate)
                return;
            for (int i = 0; i < _conveyorLoops.Length; i++)
                _conveyorLoops[i].UpdateConveyorLoop();
        }

        public void Init(List<ParallaxViewEntry> parallaxViewList)
        {
            foreach (ConveyorLoop conveyorLoop in _conveyorLoops)
            {
                for (int i = 0; i < parallaxViewList.Count; i++)
                {
                    if (parallaxViewList[i].type == conveyorLoop.Type)
                    {
                        conveyorLoop.SetQueueableListSprites(parallaxViewList[i].sprite);
                    }
                }
            }
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

        private void OnGameOverStateEnter() => _canUpdate = false;
    }
}