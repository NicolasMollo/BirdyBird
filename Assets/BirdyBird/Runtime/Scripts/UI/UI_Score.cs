using TMPro;
using UnityEngine;

namespace BirdyBird.UI
{
    public class UI_Score : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText = null;

        public void SetScoreText(string text) => _scoreText.text = text;
    }
}