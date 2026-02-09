using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Obstacle
{
    internal class ObstacleSpawner : MonoBehaviour
    {
        private List<Obstacle> _obstacleList = null;
        [SerializeField]
        private float _spawnTime = 5f;
        private float _spawnCounter = 0f;
        private bool _canSpawn = true;

        internal void SetUp(List<Obstacle> obstacleList) => _obstacleList = obstacleList;
        internal void EnableSpawn() => _canSpawn = true;
        internal void DisableSpawn() => _canSpawn = false;

        private void Update()
        {
            if (!_canSpawn)
                return;
            _spawnCounter -= Time.deltaTime;
            if (_spawnCounter <= 0)
            {
                SpawnObstacle();
                _spawnCounter = _spawnTime;
            }
        }
        private void SpawnObstacle()
        {
            int randomIndex = Random.Range(0, _obstacleList.Count);
            Obstacle toSpawn = _obstacleList[randomIndex];
            while (toSpawn.isActiveAndEnabled)
            {
                randomIndex = Random.Range(0, _obstacleList.Count);
                toSpawn = _obstacleList[randomIndex];
            }
            toSpawn.gameObject.SetActive(true);
        }

    }
}