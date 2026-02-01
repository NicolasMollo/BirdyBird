using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Environment
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ConveyorLoopMovement))]
    internal class ConveyorLoop : MonoBehaviour
    {
        private ConveyorLoopMovement _movement = null;
        private List<QueueableItem> _queueables = null;
        private QueueableItem _currentQueueable = null;
        private float _screenLeftLimit = 0f;

        private void Awake()
        {
            _movement = GetComponent<ConveyorLoopMovement>();
            _queueables = new();
            FillQueableList();
        }
        private void Start()
        {
            Camera mainCamera = Camera.main;
            Vector2 screenCenter = mainCamera.transform.position;
            float screenWidth = mainCamera.orthographicSize * 2f * mainCamera.aspect;
            _screenLeftLimit = screenCenter.x - screenWidth * 0.5f;
            EnqueueAllItem();
            _currentQueueable = _queueables[0];
        }

        internal void UpdateConveyorLoop()
        {
            _movement.Move();
            float positionX = _currentQueueable.transform.position.x + _currentQueueable.Size.x * 0.5f;
            if (positionX < _screenLeftLimit)
            {
                _currentQueueable.Enqueue(GetQueableToJoin());
                _currentQueueable = GetNextQueable();
            }
        }
        internal void IncreaseSpeed(float multiplier) => _movement.IncreaseSpeed(multiplier);
        internal void SetDirection(DirectionType direction) => _movement.SetDirection(direction);

        private void FillQueableList()
        {
            QueueableItem queable = null;
            for (int i = 0; i < transform.childCount; i++)
            {
                queable = transform.GetChild(i).gameObject.AddComponent<QueueableItem>();
                _queueables.Add(queable);
            }
        }
        private void EnqueueAllItem()
        {
            int previousIndex = 0;
            for (int i = 0; i < _queueables.Count; i++)
            {
                if (i == 0)
                    continue;
                previousIndex = i - 1;
                _queueables[i].Enqueue(_queueables[previousIndex]);
            }
        }

        private QueueableItem GetQueableToJoin()
        {
            int currentIndex = _queueables.IndexOf(_currentQueueable);
            int maxIndex = _queueables.Count - 1;
            QueueableItem toJoin = null;

            if (currentIndex == 0)
                toJoin = _queueables[maxIndex];
            else
                toJoin = _queueables[currentIndex - 1];
            return toJoin;
        }
        private QueueableItem GetNextQueable()
        {
            int currentIndex = _queueables.IndexOf(_currentQueueable);
            int maxIndex = _queueables.Count - 1;
            QueueableItem next = null;

            if (currentIndex == maxIndex)
                next = _queueables[0];
            else
                next = _queueables[++currentIndex];
            return next;
        }
    }
}