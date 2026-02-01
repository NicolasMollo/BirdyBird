using UnityEngine;

namespace BirdyBird.Environment
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    internal class QueueableItem : MonoBehaviour
    {
        private SpriteRenderer _sr = null;
        internal Vector2 Size
        {
            get { return _sr.bounds.size; }
        }

        private void Awake() => _sr = GetComponent<SpriteRenderer>();

        public void Enqueue(QueueableItem toJoin)
        {
            float positionX = toJoin.transform.position.x + toJoin.Size.x;
            Vector2 position = new Vector2(positionX, toJoin.transform.position.y);
            transform.position = position;
        }
    }
}