using UnityEngine;

namespace BirdyBird.Movement
{
    public enum DirectionType : byte
    {
        Left,
        Right,
        Up,
        Down
    }
    public class DirectionalMovement : MonoBehaviour
    {
        [SerializeField]
        private DirectionType _directionType = DirectionType.Left;
        [SerializeField]
        private float _speed = 1.0f;
        private Vector2 _direction = Vector2.zero;

        private void Awake() => SetDirection(_directionType);

        public void Move()
        {
            float calculatedSpeed = _speed * Time.deltaTime;
            Vector3 direction = _direction.normalized;
            transform.position += direction * calculatedSpeed;
        }
        public void IncreaseSpeed(float multiplier)
        {
            _speed *= multiplier;
        }
        public void SetDirection(DirectionType direction)
        {
            switch (direction)
            {
                case DirectionType.Left:
                    _direction = Vector2.left;
                    break;
                case DirectionType.Right:
                    _direction = Vector2.right;
                    break;
                case DirectionType.Up:
                    _direction = Vector2.up;
                    break;
                case DirectionType.Down:
                    _direction = Vector2.down;
                    break;
            }
        }
    }
}