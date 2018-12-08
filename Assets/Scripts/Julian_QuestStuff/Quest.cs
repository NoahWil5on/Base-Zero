using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    //InProgress or Completed
    private string questStatus;

    public string questName;
    public string location;
    public string questText;
    public Text UITextRef;

    // Use this for initialization
    void Start()
    {
        
        questStatus = "InProgress";
       
        this.transform.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        UITextRef = GameObject.FindWithTag("ObjectiveText").GetComponentInChildren<Text>();
        if (questStatus == "InProgress")
        {
            UITextRef.text = questText;

        }
        else if(questStatus == "Completed")
        {
            UITextRef.text = "Quest Completed, Return to HQ";

        }
    }
    public string getQuestStatus()
    {
        return questStatus;
    }
    public void changeQuestStatus(string newQuestStatus)
    {
        questStatus = newQuestStatus;
    }
}
