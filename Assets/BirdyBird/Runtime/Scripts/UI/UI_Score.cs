using BirdyBird.Toolkit;
using System;
using TMPro;
using UnityEngine;

namespace BirdyBird.Level.UI
{
    internal class UI_Score : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText = null;
        [SerializeField]
        private FadeableItem[] _fadeableItems = null;

        internal void SetScoreText(string text) => _scoreText.text = text;
        internal void FadeOutScore(Action onComplete)
        {
            for (int i = 0; i < _fadeableItems.Length; i++)
                _fadeableItems[i].FadeOut(i == 0 ? onComplete : null);
        }
    }
}