using UnityEngine;
using UnityEngine.SceneManagement;

namespace NightNightEngine
{
    public class PatreonScreen : MonoBehaviour
    {
        [SerializeField] private int sceneIndex = 1;

        
        public void NextScene()
        {
            Debug.Log("loadNextScene");
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }
}
