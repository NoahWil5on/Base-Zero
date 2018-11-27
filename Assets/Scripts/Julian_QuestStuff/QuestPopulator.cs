using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPopulator : MonoBehaviour {

    public struct QuestProp
    {
        public string location, endgoal, name;

        public QuestProp(string loc, string goal, string n)
        {
            location = loc;
            endgoal = goal;
            name = n;
        }
    }
    private QuestProp[] heli;
    private QuestProp[] nuke;
    private QuestProp[] misc;
    public QuestProp[] quests;
    // Use this for initialization
    void Start () {
        heli = new QuestProp[5];
        nuke = new QuestProp[5];
        misc = new QuestProp[4];
        quests = new QuestProp[5];
        //fil heli
        heli[0] = new QuestProp("train", "heli", "heli1");
        heli[1] = new QuestProp("train", "heli", "heli2");
        heli[2] = new QuestProp("hq", "heli", "heli3");
        heli[3] = new QuestProp("bunker", "heli", "heli4");
        heli[4] = new QuestProp("bunker", "heli", "heli5");
        //fill nuke

        //fill misc
        misc[0] = new QuestProp("train", "misc", "miscs");
        misc[1] = new QuestProp("train", "misc", "misct");
        misc[2] = new QuestProp("hq", "misc", "miscu");
        misc[3] = new QuestProp("bunker", "misc", "miscv");
        //if(Random.Range(0,1) == 0)
        //{
        //    
        //}
        Populate(heli);
        for(int i = 0; i < 5; i++)
        {
            
            Debug.Log(quests[i].name);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("_______________________________");
            Populate(heli);
            for (int i = 0; i < 5; i++)
            {
                Debug.Log(quests[i].name);
            }
        }
	}

    private void Populate(QuestProp[] ending)
    {
        int skipCount = 2;
        int miscInd = -1;
        int i = 0;
        for (int j = 0; j < 5; j++)
        {
            if (skipCount <= 0)
            {
                quests[i] = ending[j];
                i += 2;
            }
            if (skipCount > 0 && Random.Range(0, 2) == 1)
            {
                quests[i] = ending[j];
                i += 2;
            } else{
                skipCount--;
            }
            
            if(i > 5)
            {
                break;
            }
        }

        for (int k = 1; k < 5; k += 2)
        {
            int randNum;
            do
            {
                randNum = Random.Range(0, misc.Length);
            } while (randNum == miscInd);
            miscInd = randNum;
            quests[k] = misc[miscInd];
        }
        

    }
}
