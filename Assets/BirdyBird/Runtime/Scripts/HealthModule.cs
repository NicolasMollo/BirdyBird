using System;
using UnityEngine;

namespace BirdyBird.Modules
{
    public class HealthModule : MonoBehaviour
    {
        [SerializeField]
        private float _maxHealth = 0f;
        private float _health = 0f;
        private float Health
        {
            get
            {
                if (_health < 0f)
                {
                    _health = 0f;
                }
                else if (_health > _maxHealth)
                {
                    _health = _maxHealth;
                }
                return _health;
            }
            set { _health = value; }
        }
        private bool _isDead = false;

        public Action OnDeath = null;


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