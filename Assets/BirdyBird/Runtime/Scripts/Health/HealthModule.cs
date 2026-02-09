using System;
using UnityEngine;

namespace BirdyBird.Health
{
    public class HealthModule : MonoBehaviour
    {
        [SerializeField]
        private float _maxHealth = 0f;
        private float _health = 0f;
        private float Health
        {
            get { return _health; }
            set { _health = Mathf.Clamp(value, 0, _maxHealth); }
        }
        private bool _isDead = false;

        public event Action OnDeath = null;


        private void Awake()
        {
            Health = _maxHealth;
            _isDead = false;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health == 0 && !_isDead)
            {
                OnDeath?.Invoke();
                _isDead = true;
            }
        }

    }

}