using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "data/objective", fileName = "objective" , order = 1)]
public class objective : ScriptableObject
{
    public int id = 0;
    public string text;
}
