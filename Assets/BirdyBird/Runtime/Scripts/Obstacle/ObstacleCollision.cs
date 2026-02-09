using BirdyBird.Health;
using System;
using UnityEngine;

namespace BirdyBird.Obstacle
{
    [RequireComponent(typeof(BoxCollider2D))]
    internal class ObstacleCollision : MonoBehaviour
    {
        [SerializeField]
        private float damage = 1f;
        private BoxCollider2D _collider = null;
        internal Vector2 Size
        {
            get { return _collider.bounds.size; }
        }
        internal event Action OnCollisionWithHealthOwner = null;


        private void Awake() => _collider = GetComponent<BoxCollider2D>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<HealthModule>(out var health))
            {
                health.TakeDamage(damage);
                OnCollisionWithHealthOwner?.Invoke();
            }
        }

        internal void DisableCollision()
        {
            _collider.enabled = false;
        }
    }
}