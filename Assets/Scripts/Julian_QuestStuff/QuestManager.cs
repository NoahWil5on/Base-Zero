using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public GameObject[] HQQuests;
    public GameObject[] trainyardQuests;

    public GameObject[] currentQuests = new GameObject[3];

    private int questIndex = 0;
	// Use this for initialization
	void Start () {


        //for(int i = 0; i < 3; i++)
        //{

        //    int index = Random.Range(0, HQQuests.Length);
        //    currentQuests[i] = HQQuests[index];
        //    Destroy(HQQuests[index]);
        //}



        currentQuests[0].SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {

        currentQuests[questIndex].SetActive(true);
        string curQuestStatus = currentQuests[questIndex].GetComponent<Quest>().getQuestStatus();
        if (curQuestStatus == "Completed")
        {
            currentQuests[questIndex].SetActive(true);
            questIndex++;
        }
		

	}
}
