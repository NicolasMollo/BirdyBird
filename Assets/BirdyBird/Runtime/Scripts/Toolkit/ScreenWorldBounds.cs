using UnityEngine;

namespace BirdyBird.Toolkit
{
    public class ScreenWorldBounds
    {
        private float _screenLeftLimit = 0f;
        private float _screenRightLimit = 0f;

        public float ScreenLeftLimit 
        { 
            get { return _screenLeftLimit; } 
        }
        public float ScreenRightLimit 
        { 
            get { return _screenRightLimit; } 
        }

        public ScreenWorldBounds(Camera camera)
        {
            Vector2 screenCenter = camera.transform.position;
            float screenWidth = camera.orthographicSize * 2f * camera.aspect;
            _screenLeftLimit = screenCenter.x - screenWidth * 0.5f;
            _screenRightLimit = screenCenter.x + screenWidth * 0.5f;
        }
    }
}