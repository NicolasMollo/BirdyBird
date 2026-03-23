using System;
using UnityEngine;

namespace BirdyBird.Data
{
    public class LevelConfigurationDataContainer : MonoBehaviour
    {
        [SerializeField]
        private LevelConfigurationData _levelConfigurationData = null;

        public event Action<LevelConfigurationData> OnSetLevelConfigurationData = null;

        public void SetViewConfigurationData(LevelConfigurationData levelConfigurationData)
        {
            _levelConfigurationData = levelConfigurationData;
            OnSetLevelConfigurationData?.Invoke(_levelConfigurationData);
        }
    }
}