using UnityEngine;

namespace NightNightEngine
{
    /// <summary>
    /// Holds various game settings
    /// </summary>
    [CreateAssetMenu(menuName = "data/settings", fileName = "settings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [Header("Volumes")] 
        public float sfxVolume;
        public float musicVolume;
        public float dialogVolume;

        /// <summary>
        /// do we invert the camera mouse controls? (or joystick?)
        /// </summary>
        public bool invertY;
    }
}
