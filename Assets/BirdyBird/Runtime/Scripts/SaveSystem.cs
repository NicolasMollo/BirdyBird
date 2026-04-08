using UnityEngine;

namespace BirdyBird.Save
{
    public static class SaveSystem
    {
        private const string PLAYER_VIEWDATA_INDEX = "PlayerViewDataIndex";
        private const string ENVIRONMENT_VIEWDATA_INDEX = "EnvironmentDataIndex";
        private const string MAX_SCORE = "MaxScore";

        public static int PlayerViewDataIndex
        {
            get { return PlayerPrefs.GetInt(PLAYER_VIEWDATA_INDEX, 0); }
            set { 
                PlayerPrefs.SetInt(PLAYER_VIEWDATA_INDEX, value);
                PlayerPrefs.Save();
            }
        }
        public static int EnvironmentViewDataIndex
        {
            get { return PlayerPrefs.GetInt(ENVIRONMENT_VIEWDATA_INDEX, 0); }
            set { 
                PlayerPrefs.SetInt(ENVIRONMENT_VIEWDATA_INDEX, value);
                PlayerPrefs.Save();
            }
        }
        public static int MaxScore
        {
            get { return PlayerPrefs.GetInt(MAX_SCORE, 0); }
            set{
                PlayerPrefs.SetInt(MAX_SCORE, value);
                PlayerPrefs.Save();
            }
        }
    }
}