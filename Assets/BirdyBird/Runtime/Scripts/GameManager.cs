using BirdyBird.Environment;
using BirdyBird.Obstacle;
using BirdyBird.Player;
using BirdyBird.UI;
using BirdyBird.Score;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BirdyBird
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _player = null;
        [SerializeField]
        private ParallaxSystem _parallax = null;
        [SerializeField]
        private ObstacleSystem _obstacles = null;
        [SerializeField]
        private UI_Score _scoreUI = null;
        [SerializeField]
        private ScoreManager _scoreManager = null;


        private void Start()
        {
            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

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
            _scoreManager.OnScoreIncreased += OnScoreIncreased;
        }
        private void RemoveListeners()
        {
            _player.HealthModule.OnDeath -= OnPlayerDeath;
            _scoreManager.OnScoreIncreased -= OnScoreIncreased;
        }

        private void OnPlayerDeath()
        {
            _parallax.StopSystem();
            _obstacles.StopSystem();
        }

        private void OnScoreIncreased(int score)
        {
            _scoreUI.SetScoreText(score.ToString());
        }

    }
}