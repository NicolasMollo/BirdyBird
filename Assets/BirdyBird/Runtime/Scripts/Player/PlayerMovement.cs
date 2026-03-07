using System;
using UnityEngine;

namespace BirdyBird.Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    internal class PlayerMovement : MonoBehaviour
    {
        [Header("SETTINGS")]
        [SerializeField]
        private float _movementSpeed = 0f;
        [SerializeField]
        private float _rotationSpeed = 0f;
        [SerializeField]
        private float _minRotation = 0f;
        [SerializeField]
        private float _maxRotation = 0f;

        private Rigidbody2D _rb = null;
        private Vector2 _movementDirection = default;
        private float _rotationAngle = 0f;
        private float _rotationTarget = 0f;
        private float _currentRotationSpeed = 0f;
        private const float FALLDOWN_ROTATION_SPEED = 2f;
        private bool _canRotate = false;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _movementDirection = Vector2.up;
        }
        private void Update()
        {
            SetRotationData();
        }
        private void FixedUpdate()
        {
            if (_canRotate)
            {
                Rotate();
            }
        }

        private void Rotate()
        {
            _rb.SetRotation(Quaternion.Euler(0, 0, _rotationAngle));
        }
        private void SetRotationData()
        {
            if (_rb.velocity.y >= 0.05f)
            {
                _rotationTarget = _maxRotation;
                _currentRotationSpeed = _rotationSpeed;
            }
            else
            {
                _rotationTarget = _minRotation;
                _currentRotationSpeed = FALLDOWN_ROTATION_SPEED;
            }
            _rotationAngle = Mathf.MoveTowards(_rb.rotation, _rotationTarget, _currentRotationSpeed);
        }

        internal void Move()
        {
            Vector2 directionNormalized = _movementDirection.normalized;
            Vector2 velocity = directionNormalized * _movementSpeed;

            _rb.velocity = velocity;
        }
        internal void Disable()
        {
            _rb.constraints = RigidbodyConstraints2D.FreezeAll;
            _canRotate = false;
        }
        internal void Enable()
        {
            _canRotate = true;
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

    }
}