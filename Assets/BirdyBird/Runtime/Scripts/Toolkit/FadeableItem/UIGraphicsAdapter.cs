using UnityEngine;
using UnityEngine.UI;

namespace BirdyBird.Toolkit
{
    public class UIGraphicsAdapter : GraphicsAdapter
    {
        private MaskableGraphic _maskable = null;
        public override Color Color { get => _maskable.color; set => _maskable.color = value; }

        private void Awake() => _maskable = GetComponent<MaskableGraphic>();
    }
}