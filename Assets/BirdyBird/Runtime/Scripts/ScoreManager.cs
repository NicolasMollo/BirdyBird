using BirdyBird.Events;
using System;
using UnityEngine;

namespace BirdyBird.Score
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score = 0;
        public event Action<int> OnScoreIncreased = null;

        private void Start() => GameEventBus.OnScoreTriggerCollision += OnScoreTriggerCollisionExit;
        private void OnDestroy() => GameEventBus.OnScoreTriggerCollision -= OnScoreTriggerCollisionExit;

        private void OnScoreTriggerCollisionExit()
        {
            _score++;
            OnScoreIncreased?.Invoke(_score);
        }
    }
}