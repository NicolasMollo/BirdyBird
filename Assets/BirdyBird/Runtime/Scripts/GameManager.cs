using BirdyBird.Environment;
using BirdyBird.Obstacle;
using BirdyBird.Player;
using UnityEngine;

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
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                // _parallax.IncreaseSpeed(1.5f);
            }
        }

        private void AddListeners()
        {
            _player.HealthModule.OnDeath += OnPlayerDeath;
        }
        private void RemoveListeners()
        {
            _player.HealthModule.OnDeath -= OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            _parallax.StopSystem();
            _obstacles.StopSystem();
        }

    }
}