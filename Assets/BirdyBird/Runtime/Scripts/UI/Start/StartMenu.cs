using BirdyBird.Data;
using BirdyBird.DummyPlayer;
using BirdyBird.Environment;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BirdyBird.UI.Start
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton = null;
        [SerializeField]
        private PlayerSelectionBlock _playerSelectionBlock = null;
        [SerializeField]
        private ParallaxSelectionBlock _parallaxBlock = null;


        [SerializeField]
        private DummyPlayerController _dummyPlayer = null;
        [SerializeField]
        private ParallaxSystem _dummyParallax = null;
        [SerializeField]
        private LevelConfigurationData _levelConfigurationData = null;

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

        private void OnClickPlayButton()
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }

        private void OnSelectPlayerViewData(PlayerViewData data)
        {
            _levelConfigurationData.playerViewData = data;
            _dummyPlayer.SetAnimatorController(_levelConfigurationData.playerViewData.AnimatorController);
        }
        private void OnSelectParallaxViewData(ParallaxViewData data)
        {
            _levelConfigurationData.parallaxViewData = data;
            _dummyParallax.Init(_levelConfigurationData.parallaxViewData.SpriteList);
        }

    }
}