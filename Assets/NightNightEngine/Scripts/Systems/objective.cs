using UnityEngine;

namespace NightNightEngine
{
    /// <summary>
    /// A simple class for holding objective data
    /// </summary>
    [CreateAssetMenu(menuName = "data/objective", fileName = "objective", order = 1)]
    public class Objective : ScriptableObject
    {
        /// <summary>
        /// a public identifier for reacting to what objective the player currently has (aids in game flow)
        /// </summary>
        public int id;

        /// <summary>
        /// The actual text of the objective so the player can know what they are supposed to be doing.
        /// </summary>
        public string text;
    }
}
