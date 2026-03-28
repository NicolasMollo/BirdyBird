using BirdyBird.Data;
using BirdyBird.Start.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BirdyBird.Start
{
    public class StartSceneController : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton = null;
        [SerializeField]
        private PlayerSelectionBlock _playerSelectionBlock = null;
        [SerializeField]
        private ParallaxSelectionBlock _parallaxBlock = null;
        [SerializeField]
        private LevelConfigurationData _levelConfigurationData = null;
        [SerializeField]
        private LevelPreviewController _levelPreview = null;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnClickPlayButton);
            _playerSelectionBlock.OnSelectViewData += OnSelectPlayerViewData;
            _parallaxBlock.OnSelectViewData += OnSelectParallaxViewData;
        }
        private void OnDisable()
        {
            _parallaxBlock.OnSelectViewData -= OnSelectParallaxViewData;
            _playerSelectionBlock.OnSelectViewData -= OnSelectPlayerViewData;
            _playButton.onClick.RemoveListener(OnClickPlayButton);
        }

        private void OnClickPlayButton() => SceneManager.LoadScene(2, LoadSceneMode.Single);

        private void OnSelectPlayerViewData(PlayerViewData data)
        {
            _levelConfigurationData.playerViewData = data;
            _levelPreview.UpdatePlayerView(_levelConfigurationData.playerViewData);
        }
        private void OnSelectParallaxViewData(ParallaxViewData data)
        {
            _levelConfigurationData.parallaxViewData = data;
            _levelPreview.UpdateParallaxView(_levelConfigurationData.parallaxViewData);
        }

    }
}