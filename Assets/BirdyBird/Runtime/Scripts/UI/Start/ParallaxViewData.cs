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

    [CreateAssetMenu(menuName = "SO/ViewData/Parallax")]
    public class ParallaxViewData : BaseViewData
    {
        [SerializeField]
        private List<ParallaxViewEntry> _spriteList = null;
        public List<ParallaxViewEntry> SpriteList
        {
            get { return _spriteList; }
            set { _spriteList = value; }
        }
    }
}