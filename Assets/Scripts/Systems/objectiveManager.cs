using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class objectiveManager : MonoBehaviour
{
    public objective currentObjective;
    public Animator objectiveUIAnim;
    public TextMeshProUGUI objectiveText;

    public static objectiveManager instance;
    
    // Start is called before the first frame update
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(instance!=this)
                Destroy((this));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateObjective(objective newObjective)
    {
        currentObjective = newObjective;
        objectiveText.text = currentObjective.text;
        objectiveUIAnim.SetTrigger("show");
    }

    public int currentObjectiveID()
    {
        return currentObjective.id;
    }
}
