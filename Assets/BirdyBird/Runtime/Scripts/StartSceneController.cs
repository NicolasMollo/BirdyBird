using BirdyBird.Data;
using BirdyBird.Save;
using BirdyBird.Start.UI;
using TMPro;
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
        private Button _exitButton = null;
        [SerializeField]
        private TextMeshProUGUI _gameTitle = null;
        [SerializeField]
        private PlayerSelectionBlock _playerSelectionBlock = null;
        [SerializeField]
        private LevelSelectionBlock _parallaxBlock = null;
        [SerializeField]
        private LevelConfigurationData _levelConfigurationData = null;
        [SerializeField]
        private LevelPreviewController _levelPreview = null;

        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();
        private void Start()
        {
            _playerSelectionBlock.Init(SaveSystem.PlayerViewDataIndex);
            _parallaxBlock.Init(SaveSystem.EnvironmentViewDataIndex);
        }

        private void AddListeners()
        {
            _playButton.onClick.AddListener(OnClickPlayButton);
            _exitButton.onClick.AddListener(OnClickExitButton);
            _playerSelectionBlock.OnSelectViewData += OnSelectPlayerViewData;
            _parallaxBlock.OnSelectViewData += OnSelectParallaxViewData;
        }
        private void RemoveListeners()
        {
            _parallaxBlock.OnSelectViewData -= OnSelectParallaxViewData;
            _playerSelectionBlock.OnSelectViewData -= OnSelectPlayerViewData;
            _exitButton.onClick.RemoveListener(OnClickExitButton);
            _playButton.onClick.RemoveListener(OnClickPlayButton);
        }

        private void OnClickPlayButton() => SceneManager.LoadScene(2, LoadSceneMode.Single);
        private void OnClickExitButton() => Application.Quit();

        private void OnSelectPlayerViewData(PlayerViewData data, int index)
        {
            _levelConfigurationData.playerViewData = data;
            _levelPreview.UpdatePlayerView(_levelConfigurationData.playerViewData);
            SaveSystem.PlayerViewDataIndex = index;
        }
        private void OnSelectParallaxViewData(LevelViewData data, int index)
        {
            _levelConfigurationData.parallaxViewData = data;
            _levelPreview.UpdateParallaxView(_levelConfigurationData.parallaxViewData);
            _gameTitle.color = _levelConfigurationData.parallaxViewData.TextsColor;
            SaveSystem.EnvironmentViewDataIndex = index;
        }

    }
}