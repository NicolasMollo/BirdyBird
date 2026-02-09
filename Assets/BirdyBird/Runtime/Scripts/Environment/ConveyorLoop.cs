using BirdyBird.Movement;
using BirdyBird.Toolkit;
using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Environment
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DirectionalMovement))]
    internal class ConveyorLoop : MonoBehaviour
    {
        private DirectionalMovement _movement = null;
        private List<QueueableItem> _queueableList = null;
        private QueueableItem _currentQueueable = null;
        private ScreenWorldBounds _screenBounds = null;

        private void Awake()
        {
            _movement = GetComponent<DirectionalMovement>();
            _screenBounds = new ScreenWorldBounds(Camera.main);
            _queueableList = new();
            FillQueableList();
        }
        private void Start()
        {
            EnqueueAllItem();
            _currentQueueable = _queueableList[0];
        }

        internal void UpdateConveyorLoop()
        {
            _movement.Move();
            float positionX = _currentQueueable.transform.position.x + _currentQueueable.Size.x * 0.5f;
            if (positionX < _screenBounds.ScreenLeftLimit)
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
                _queueableList.Add(queable);
            }
        }
        private void EnqueueAllItem()
        {
            int previousIndex = 0;
            for (int i = 0; i < _queueableList.Count; i++)
            {
                if (i == 0)
                    continue;
                previousIndex = i - 1;
                _queueableList[i].Enqueue(_queueableList[previousIndex]);
            }
        }

        private QueueableItem GetQueableToJoin()
        {
            int currentIndex = _queueableList.IndexOf(_currentQueueable);
            int maxIndex = _queueableList.Count - 1;
            QueueableItem toJoin = null;

            if (currentIndex == 0)
                toJoin = _queueableList[maxIndex];
            else
                toJoin = _queueableList[currentIndex - 1];
            return toJoin;
        }
        private QueueableItem GetNextQueable()
        {
            int currentIndex = _queueableList.IndexOf(_currentQueueable);
            int maxIndex = _queueableList.Count - 1;
            QueueableItem next = null;

            if (currentIndex == maxIndex)
                next = _queueableList[0];
            else
                next = _queueableList[++currentIndex];
            return next;
        }
    }
}