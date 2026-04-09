using BirdyBird.Events;
using BirdyBird.Save;
using System;
using UnityEngine;

namespace BirdyBird.Score
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score = 0;
        private int _bestScore = 0;
        public int Score { get { return _score; } }
        public int BestScore { get { return _bestScore; } }
        public event Action<int> OnScoreChanged = null;

        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();
        private void Start() => _bestScore = SaveSystem.BestScore;

        private void AddListeners()
        {
            GameEventBus.OnScoreTriggerCollision += OnScoreTriggerCollision;
            GameEventBus.OnGameStateExit += OnGameStateExit;
        }
        private void RemoveListeners()
        {
            GameEventBus.OnGameStateExit -= OnGameStateExit;
            GameEventBus.OnScoreTriggerCollision -= OnScoreTriggerCollision;
        }
        private void OnScoreTriggerCollision()
        {
            _score++;
            OnScoreChanged?.Invoke(_score);
        }

        private void OnGameStateExit()
        {
            if (_score > _bestScore)
            {
                _bestScore = _score;
                SaveSystem.BestScore = _bestScore;
            }
        }
    }
}