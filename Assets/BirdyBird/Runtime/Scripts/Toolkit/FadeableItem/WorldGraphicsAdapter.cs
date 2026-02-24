using UnityEngine;

namespace BirdyBird.Toolkit
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class WorldGraphicsAdapter : GraphicsAdapter
    {
        private SpriteRenderer _sr = null;
        public override Color Color { get => _sr.color; set => _sr.color = value; }

        private void Awake() => _sr = GetComponent<SpriteRenderer>();
    }
}