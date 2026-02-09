using BirdyBird.Player;
using System;
using UnityEngine;

namespace BirdyBird.Obstacle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ScoreTrigger : MonoBehaviour
    {
        public event Action OnCollideWithPlayer = null;

        private void Awake()
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.isTrigger = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerController>(out _))
            {
                OnCollideWithPlayer?.Invoke();
            }
        }
    }
}