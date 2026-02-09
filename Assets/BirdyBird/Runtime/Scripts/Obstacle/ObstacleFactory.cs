using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Obstacle
{
    internal class ObstacleFactory
    {
        internal List<Obstacle> CreateObstaclePool(GameObject prefab, Transform parent, int poolSize)
        {
            List<Obstacle> obstacles = new();
            Obstacle temp = null;
            for (int i = 0; i < poolSize; i++)
            {
                temp = CreateObstacle(prefab, parent);
                obstacles.Add(temp);
            }
            return obstacles;
        }
        private Obstacle CreateObstacle(GameObject prefab, Transform parent)
        {
            GameObject obj = GameObject.Instantiate(prefab, parent.position, Quaternion.identity, parent);
            Obstacle compoundObstacle = obj.GetComponent<Obstacle>();
            return compoundObstacle;
        }
    }
}