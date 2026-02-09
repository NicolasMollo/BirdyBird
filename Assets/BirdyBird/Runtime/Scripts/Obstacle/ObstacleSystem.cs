using BirdyBird.Movement;
using BirdyBird.Toolkit;
using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Obstacle
{
    [RequireComponent(typeof(ObstacleSpawner))]
    public class ObstacleSystem : MonoBehaviour
    {
        [SerializeField]
        private ObstaclePooler _pooler = null;
        private ObstacleSpawner _spawner = null;
        private List<Obstacle> _obstacleList = null;
        private bool _canUpdate = false;

        private const float POSITION_OFFSET = 2f;

        private void Awake()
        {
            _spawner = GetComponent<ObstacleSpawner>();
            _obstacleList = new();
            _canUpdate = true;
        }
        private void Start()
        {
            SetPosition();
            _obstacleList = _pooler.CreatePool(transform);
            foreach (Obstacle obstacle in _obstacleList)
            {
                obstacle.OnOutOfScreenLeftBound += OnCompoundObstacleIsOutOfScreen;
                obstacle.gameObject.SetActive(false);
            }
            _spawner.SetUp(_obstacleList);
        }
        private void OnDestroy()
        {
            foreach (Obstacle obstacle in _obstacleList)
                obstacle.OnOutOfScreenLeftBound -= OnCompoundObstacleIsOutOfScreen;
        }
        private void Update()
        {
            if (!_canUpdate)
                return;
            for (int i = 0; i < _obstacleList.Count; i++)
            {
                if (_obstacleList[i].isActiveAndEnabled)
                    _obstacleList[i].UpdateObstacle();
            }
        }

        private void SetPosition()
        {
            ScreenWorldBounds screenBounds = new(Camera.main);
            Vector2 position =
             new Vector2(screenBounds.ScreenRightLimit + POSITION_OFFSET, transform.position.y);
            transform.position = position;
        }
        public void StopSystem()
        {
            _canUpdate = false;
            _spawner.DisableSpawn();
        }
        public void StartSystem()
        {
            _canUpdate = true;
            _spawner.EnableSpawn();
        }

        public void IncreaseSpeed(float multiplier)
        {
            for (int i = 0; i < _obstacleList.Count; i++)
                _obstacleList[i].IncreaseSpeed(multiplier);
        }
        public void SetDirection(DirectionType direction)
        {
            for (int i = 0; i < _obstacleList.Count; i++)
                _obstacleList[i].SetDirection(direction);
        }

        private void OnCompoundObstacleIsOutOfScreen(Transform transform)
        {
            transform.gameObject.SetActive(false);
            transform.position = this.transform.position;
        }

    }
}