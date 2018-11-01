using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{

    private string questStatus;

    public string questName;

    public Text uiText;

    // Use this for initialization
    void Start()
    {
        this.transform.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

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
