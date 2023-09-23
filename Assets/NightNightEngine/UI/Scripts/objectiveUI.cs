using UnityEngine;

namespace NightNightEngine.UI
{
    public class ObjectiveUI : MonoBehaviour
    {
        [SerializeField] private AudioSource soundPlayer;
       

        // Update is called once per frame
        void PlaySound()
        {
            soundPlayer.Play();
        }
    }
}
