using UnityEngine;

namespace BirdyBird.UI.Start
{
    [CreateAssetMenu(menuName = "SO/ViewData/Player")]
    public class PlayerViewData : BaseViewData
    {
        [SerializeField]
        private RuntimeAnimatorController _animatorController = null;
        public RuntimeAnimatorController AnimatorController
        {
            get { return _animatorController; } 
            set { _animatorController = value; }
        }
    }
}