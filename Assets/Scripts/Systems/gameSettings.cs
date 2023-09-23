using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "data/settings", fileName = "settings" , order = 0)]
public class gameSettings : ScriptableObject
{
    public float sfxVolume;
    public float musicVolume;
    public float dialogVolume;

    public bool invertY;
}
