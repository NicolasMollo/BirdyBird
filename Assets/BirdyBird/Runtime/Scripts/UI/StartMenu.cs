using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BirdyBird.UI
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton = null;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnClickPlayButton);
        }
        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnClickPlayButton);
        }

        private void OnClickPlayButton()
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }

    }
}