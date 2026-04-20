using System;
using System.Collections;
using UnityEngine;

namespace BirdyBird.Toolkit
{
    public class FadeableItem : MonoBehaviour
    {
        [SerializeField, Range(0f, 255f)]
        private float _fadeInTreshold = 0f;
        [SerializeField, Range(0f, 255f)]
        private float _fadeOutTreshold = 0f;
        [SerializeField, Range(0f, 10f)]
        private float _fadeInDelay = 0f;
        [SerializeField, Range(0f, 10f)]
        private float _fadeOutDelay = 0f;
        private GraphicsAdapter _graphicsAdapter = null;

        private void Awake()
        {
            if (transform is RectTransform _)
                _graphicsAdapter = gameObject.AddComponent<UIGraphicsAdapter>();
            else
                _graphicsAdapter = gameObject.AddComponent<WorldGraphicsAdapter>();
        }

        public void FadeIn(Action onComplete = null) => StartCoroutine(PrivateFadeIn(onComplete));
        public void FadeOut(Action onComplete = null) => StartCoroutine(PrivateFadeOut(onComplete));

        private IEnumerator PrivateFadeIn(Action onComplete)
        {
            float startAlpha = _graphicsAdapter.Color.a;
            float targetAlpha = _fadeInTreshold / 255f;
            float time = 0f;

            while (time < _fadeInDelay)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / _fadeInDelay);

                _graphicsAdapter.Color = new Color(
                    _graphicsAdapter.Color.r,
                    _graphicsAdapter.Color.g,
                    _graphicsAdapter.Color.b,
                    alpha
                );

                yield return null;
            }

            onComplete?.Invoke();
        }

        private IEnumerator PrivateFadeOut(Action onComplete)
        {
            float startAlpha = _graphicsAdapter.Color.a;
            float targetAlpha = _fadeOutTreshold / 255f;
            float time = 0f;

            while (time < _fadeOutDelay)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / _fadeOutDelay);

                _graphicsAdapter.Color = new Color(
                    _graphicsAdapter.Color.r,
                    _graphicsAdapter.Color.g,
                    _graphicsAdapter.Color.b,
                    alpha
                );

                yield return null;
            }
            _graphicsAdapter.Color = new Color(
                _graphicsAdapter.Color.r,
                _graphicsAdapter.Color.g,
                _graphicsAdapter.Color.b,
                targetAlpha
            );

            onComplete?.Invoke();
        }
    }
}