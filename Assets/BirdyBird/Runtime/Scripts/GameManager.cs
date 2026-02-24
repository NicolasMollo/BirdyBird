using BirdyBird.AI;
using BirdyBird.Player;
using BirdyBird.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BirdyBird
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Fsm _fsm = null;
        [SerializeField]
        private PlayerController _player = null;
        [SerializeField]
        private UISystem _UI = null;

        private void Start()
        {
            _fsm.Init();
            AddListeners();
        }
        private void OnDestroy() => RemoveListeners();

       

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                // _parallax.StopParallax();
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                // _parallax.IncreaseSpeed(1.5f);
            }
        }

        private void AddListeners()
        {
            _player.HealthModule.OnDeath += OnPlayerDeath;
            _UI.SubOnReloadButtonClick(OnReloadButtonClick);
        }
        private void RemoveListeners()
        {
            _player.HealthModule.OnDeath -= OnPlayerDeath;
            _UI.UnsubFromOnReloadButtonClick(OnReloadButtonClick);
        }

        private void OnPlayerDeath()
        {
            _fsm.ChangeState<GameOverState>();
        }
        private void OnReloadButtonClick()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

    }
}