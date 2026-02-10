using BirdyBird.Events;
using BirdyBird.Player;
using System;
using UnityEngine;

namespace BirdyBird.Obstacle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ScoreTrigger : MonoBehaviour
    {
        private BoxCollider2D _collider = null;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerController>(out _))
            {
                GameEventBus.CallOnScoreTriggerCollision();
            }
        }

        public void DisableCollision()
        {
            _collider.enabled = false;
        }
    }
}