using BirdyBird.Start.UI;
using UnityEngine;

namespace BirdyBird.Data
{
    [CreateAssetMenu(menuName = "SO/LevelConfigurationData")]
    public class LevelConfigurationData : ScriptableObject
    {
        public PlayerViewData playerViewData = null;
        public ParallaxViewData parallaxViewData = null;
    }
}