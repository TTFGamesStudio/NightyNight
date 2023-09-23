using UnityEngine;

namespace NightNightEngine
{
    /// <summary>
    /// The Game manager class stores settings data and saves/loads it into and out of player prefs. (There should only
    /// be one game manager active per game, so it impliments the singleton pattern)
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        ///the game manager, used for storing/saving data used across all objects of the game
        /// </summary>
        public static GameManager instance;

        /// <summary>
        /// holds settings data such as volume or camera inversion settings
        /// </summary>
        public GameSettings settings;

        /// <summary>
        /// has the game been paused? mainly used by other classes to determine if they should execute code or not.
        /// </summary>
        public bool gamePaused = false;


        void Start()
        {
            if (instance == null)
            {
                instance = this;

            }
            else
            {
                Destroy(this);
            }
        }
    }
}
