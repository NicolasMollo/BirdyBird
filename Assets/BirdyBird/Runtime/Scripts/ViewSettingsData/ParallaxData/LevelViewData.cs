using BirdyBird.Environment;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BirdyBird.Start.UI
{
    [Serializable]
    public struct ParallaxViewEntry
    {
        public ConveyorLoopType type;
        public Sprite sprite;
    }

    [CreateAssetMenu(menuName = "SO/ViewData/Level")]
    public class LevelViewData : BaseViewData
    {
        [SerializeField]
        private List<ParallaxViewEntry> _spriteList = null;
        public List<ParallaxViewEntry> SpriteList
        {
            get { return _spriteList; }
            set { _spriteList = value; }
        }

        [field:SerializeField]
        public Color TextsColor {  get; private set; }
        [field:SerializeField]
        public Color ScoreBackgroundColor { get; private set; }
        [field: SerializeField]
        public AudioClip Clip { get; private set; }
    }
}