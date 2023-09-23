using TMPro;
using UnityEngine;

namespace NightNightEngine
{
    /// <summary>
    /// The objective manager stores and displays the current objective, this is a singleton.
    /// </summary>
    public class ObjectiveManager : MonoBehaviour
    {
        /// <summary>
        /// The Objective the the player is currently On
        /// </summary>
        [SerializeField] private Objective currentObjective;

        /// <summary>
        /// the animator for displaying the UI itself
        /// </summary>
        [SerializeField] private Animator objectiveUIAnim;

        /// <summary>
        /// The text object for the current objective
        /// </summary>
        [SerializeField] private TextMeshProUGUI objectiveText;

        /// <summary>
        /// an instance of the objective manager so we can easily get a reference to it
        /// </summary>
        public static ObjectiveManager Instance;

        // Start is called before the first frame update

        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                if (Instance != this)
                    Destroy((this));
            }
        }

        /// <summary>
        /// Calling this function will result in a new objective becoming active
        /// </summary>
        public void UpdateObjective(Objective newObjective)
        {
            currentObjective = newObjective;
            objectiveText.text = currentObjective.text;
            objectiveUIAnim.SetTrigger("show");
        }

        /// <summary>
        /// get the current objectives ID
        /// </summary>
        public int CurrentObjectiveID()
        {
            return currentObjective.id;
        }
    }
}
