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
        [SerializeField, Range(0f, 0.1f)]
        private float _fadeInDelay = 0f;
        [SerializeField, Range(0f, 0.1f)]
        private float _fadeOutDelay = 0f;
        private GraphicsAdapter _graphicsAdapter = null;
        private const float FADE_OFFSET = 0.01f;

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
            float alpha = _graphicsAdapter.Color.a;
            float normalizedTreshold = _fadeInTreshold / 255f;
            while (alpha < normalizedTreshold)
            {
                alpha += FADE_OFFSET;
                _graphicsAdapter.Color = new Color(
                    _graphicsAdapter.Color.r,
                    _graphicsAdapter.Color.g,
                    _graphicsAdapter.Color.b,
                    alpha
                    );
                yield return new WaitForSeconds(_fadeInDelay);
            }
            onComplete?.Invoke();
        }
        private IEnumerator PrivateFadeOut(Action onComplete)
        {
            float alpha = _graphicsAdapter.Color.a;
            float normalizedTreshold = _fadeOutTreshold / 255f;
            while (alpha > normalizedTreshold)
            {
                alpha -= FADE_OFFSET;
                _graphicsAdapter.Color = new Color(
                    _graphicsAdapter.Color.r,
                    _graphicsAdapter.Color.g,
                    _graphicsAdapter.Color.b,
                    alpha
                    );
                yield return new WaitForSeconds(_fadeOutDelay);
            }
            onComplete?.Invoke();
        }
    }
}