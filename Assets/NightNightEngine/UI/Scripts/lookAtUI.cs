using UnityEngine;
using NightNightEngine;
using TMPro;

namespace NightNightEngine.UI
{
    public class lookAtUI : MonoBehaviour
    {
        public TextMeshProUGUI textDisplay;
        public Animator uiAnim;

        public void beginLook(string data)
        {
            textDisplay.text = data;
            uiAnim.SetBool("showing",true);
        }

        public void endLook()
        {
            uiAnim.SetBool("showing",false);
        }
        
    }
}
