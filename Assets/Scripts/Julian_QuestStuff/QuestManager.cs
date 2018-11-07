using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public GameObject[] HQQuests;
    public GameObject[] trainyardQuests;

    public GameObject[] currentQuests = new GameObject[3];
	// Use this for initialization
	void Start () {


        currentQuests[0].SetActive(true);
        //for(int i = 0; i < 3; i++)
        //{

        //    int index = Random.Range(0, HQQuests.Length);
        //    currentQuests[i] = HQQuests[index];
        //    Destroy(HQQuests[index]);
        //}


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
