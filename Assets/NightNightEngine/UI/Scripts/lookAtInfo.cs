using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NightNightEngine.UI
{
    [CreateAssetMenu (fileName = "lookAtData", menuName = "data/lookAt", order = 2)]
    public class LookAtInfo : ScriptableObject
    {
        public string displayName;
        public string text;
    }
}
