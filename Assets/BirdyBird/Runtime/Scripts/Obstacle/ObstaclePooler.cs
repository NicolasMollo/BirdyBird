using System;
using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Obstacle
{
    [Serializable]
    internal class ObstaclePooler
    {
        private ObstacleFactory _factory = new();
        [SerializeField]
        private List<GameObject> _prefabObstacleList = null;
        [SerializeField]
        [Tooltip("Number of object to create per type of prefab")]
        private int _poolSizePerObstacles = 3;

        internal List<Obstacle> CreatePool(Transform parent)
        {
            List<Obstacle> temp = new();
            List<Obstacle> toReturn = new();
            foreach (GameObject prefab in _prefabObstacleList)
            {
                temp = _factory.CreateObstaclePool(prefab, parent, _poolSizePerObstacles);
                toReturn.AddRange(temp);
            }
            return toReturn;
        }
    }
}