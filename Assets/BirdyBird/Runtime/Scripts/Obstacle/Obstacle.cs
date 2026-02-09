using BirdyBird.Movement;
using BirdyBird.Toolkit;
using System;
using UnityEngine;

namespace BirdyBird.Obstacle
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DirectionalMovement))]
    internal class Obstacle : MonoBehaviour
    {
        [SerializeField]
        private ObstacleCollision[] _collisionArray = null;
        private Vector2 _biggerCollisionSize = Vector2.zero;
        private DirectionalMovement _movement = null;
        private ScreenWorldBounds _screenBounds = null;
        internal event Action<Transform> OnOutOfScreenLeftBound = null;

        private void Awake()
        {
            _screenBounds = new(Camera.main);
            _movement = GetComponent<DirectionalMovement>();
        }
        private void Start()
        {
            SetBiggerObstacleCollision();
            AddListeners();
        }
        private void OnDestroy()
        {
            RemoveListeners();
        }

        internal void UpdateObstacle()
        {
            _movement.Move();
            float positionX = transform.position.x + _biggerCollisionSize.x * 0.5f;
            if (positionX < _screenBounds.ScreenLeftLimit)
            {
                OnOutOfScreenLeftBound?.Invoke(transform);
            }
        }
        internal void IncreaseSpeed(float multiplier) => _movement.IncreaseSpeed(multiplier);
        internal void SetDirection(DirectionType direction) => _movement.SetDirection(direction);

        private void AddListeners()
        {
            for (int i = 0; i < _collisionArray.Length; i++)
                _collisionArray[i].OnCollisionWithHealthOwner += OnCollisionWithHealthOwner;
        }
        private void RemoveListeners()
        {
            for (int i = 0; i < _collisionArray.Length; i++)
                _collisionArray[i].OnCollisionWithHealthOwner -= OnCollisionWithHealthOwner;
        }

        private void OnCollisionWithHealthOwner()
        {
            for (int i = 0; i < _collisionArray.Length; i++)
                _collisionArray[i].DisableCollision();
        }

        private void SetBiggerObstacleCollision()
        {
            Vector2[] sizes = new Vector2[_collisionArray.Length];
            for (int i = 0; i < sizes.Length; i++)
            {
                sizes[i] = _collisionArray[i].Size;
                if (i == 0)
                    continue;
                if (sizes[i].x > sizes[i - 1].x)
                    _biggerCollisionSize = sizes[i];
            }
        }
    }
}