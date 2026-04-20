using BirdyBird.Environment;
using BirdyBird.Start.UI;
using UnityEngine;

namespace BirdyBird.Start
{
    internal class LevelPreviewController : MonoBehaviour
    {
        [SerializeField]
        private PreviewPlayerController _previewPlayer = null;
        [SerializeField]
        private ParallaxSystem _previewParallax = null;

        internal void UpdatePlayerView(PlayerViewData data) => _previewPlayer.SetAnimatorController(data.AnimatorController);
        internal void UpdateParallaxView(LevelViewData data) => _previewParallax.Init(data.SpriteList);
    }
}