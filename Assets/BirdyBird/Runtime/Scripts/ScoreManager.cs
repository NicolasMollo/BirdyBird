using BirdyBird.Events;
using System;
using UnityEngine;

namespace BirdyBird.Score
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score = 0;
        public int Score { get { return _score; } }
        public event Action<int> OnScoreChanged = null;

        private void OnEnable() => GameEventBus.OnScoreTriggerCollision += OnScoreTriggerCollision;
        private void OnDisable() => GameEventBus.OnScoreTriggerCollision -= OnScoreTriggerCollision;

        private void OnScoreTriggerCollision()
        {
            _score++;
            OnScoreChanged?.Invoke(_score);
        }
    }
}