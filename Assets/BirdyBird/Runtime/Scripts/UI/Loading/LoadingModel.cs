using System;
using UnityEngine;

namespace BirdyBird.UI.Loading
{
    internal class LoadingModel : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 10.0f)]
        private float _delay = 0f;
        private float _elapsedTime = 0f;
        private bool _isCompleted = false;
        internal float ElapsedTime
        {
            get { return _elapsedTime; }
            set { _elapsedTime = Mathf.Clamp(value, 0, _delay); }
        }
        internal float TimePercentage
        {
            get { return ElapsedTime / _delay; }
        }

        internal event Action OnDelayReached = null;


        private void Update()
        {
            ElapsedTime += Time.deltaTime;
            if (ElapsedTime >= _delay && !_isCompleted)
            {
                _isCompleted = true;
                OnDelayReached?.Invoke();
            }
        }

    }
}