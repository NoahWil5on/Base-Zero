using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public GameObject[] questDatabase;

    public GameObject[] currentQuests = new GameObject[5];

    private QuestPopulator qp;
    private bool questsWereAdded = true;

    public int questIndex = 0;

    public GameObject navArrow;
    private arrowHandler arrowHandler;

    public static QuestManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {

        DontDestroyOnLoad(this.gameObject);
        arrowHandler = navArrow.GetComponent<arrowHandler>();
        qp = this.GetComponent<QuestPopulator>();
        //for(int i = 0; i < 3; i++)
        //{

        //    int index = Random.Range(0, HQQuests.Length);
        //    currentQuests[i] = HQQuests[index];
        //    Destroy(HQQuests[index]);
        //}

       // currentQuests[0].SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {
       
        navArrow = GameObject.FindGameObjectWithTag("Arrow");
        if (questsWereAdded)
        {
            generateQuests(qp.getQuestNames());
            Debug.Log("Here");
            questsWereAdded = false;
        }
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {

            string[] s = qp.getQuestNames();
            for (int i = 0; i < s.Length; i++)
                Debug.Log(s[i]);
        }

        currentQuests[questIndex].SetActive(true);
        string curQuestStatus = currentQuests[questIndex].GetComponent<Quest>().getQuestStatus();
        if (curQuestStatus == "Completed")
        {
            currentQuests[questIndex].SetActive(false);
            questIndex++;
            arrowHandler.onObjectiveChange();
        }
        if(questIndex >= 6)
        {
            SceneManager.LoadScene(4);
        }


    }
    public string sendCurQuestName()
    {
        return currentQuests[questIndex].name;
    }
    public string sendCurQuestLocation()
    {
        return currentQuests[questIndex].GetComponent<Quest>().location;
    }
    public GameObject returnQuestGO(string tag)
    {
        switch (tag)
        {
            case "Heli1":
                return questDatabase[0];
            case "Heli2":
                return questDatabase[1];
            case "Heli3":
                return questDatabase[2];
            case "Heli4":
                return questDatabase[3];
            case "Heli5":
                return questDatabase[4];
            case "Nuke1":
                return questDatabase[5];
            case "Nuke2":
                return questDatabase[6];
            case "Nuke3":
                return questDatabase[7];
            case "Nuke4":
                return questDatabase[8];
            case "Nuke5":
                return questDatabase[9];
            case "Misc1":
                return questDatabase[10];
            case "Misc2":
                return questDatabase[11];
            case "Misc3":
                return questDatabase[12];
            case "Misc4":
                return questDatabase[13];
         
        }
        return null;
    }
    private void generateQuests(string[] questPopulatedArr)
    {
        currentQuests[5] = questDatabase[14];
        for(int i = 0; i < questPopulatedArr.Length; i++)
        {
            string cur = questPopulatedArr[i];

        

            switch (cur)
            {
                case "heli1":
                    currentQuests[i] = questDatabase[0];
                    break;
                case "heli2":
                    currentQuests[i] = questDatabase[1];
                    break;
                case "heli3":
                    currentQuests[i] = questDatabase[2];
                    break;
                case "heli4":
                    currentQuests[i] = questDatabase[3];
                    break;
                case "heli5":
                    currentQuests[i] = questDatabase[4];
                    break;
                case "nuke1":
                    currentQuests[i] = questDatabase[5];
                    break;
                case "nuke2":
                    currentQuests[i] = questDatabase[6];
                    break;
                case "nuke3":
                    currentQuests[i] = questDatabase[7];
                    break;
                case "nuke4":
                    currentQuests[i] = questDatabase[8];
                    break;
                case "nuke5":
                    currentQuests[i] = questDatabase[9];
                    break;
                case "misc1":
                    currentQuests[i] = questDatabase[10];
                    break;
                case "misc2":
                    currentQuests[i] = questDatabase[11];
                    break;
                case "misc3":
                    currentQuests[i] = questDatabase[12];
                    break;
                case "misc4":
                    currentQuests[i] = questDatabase[13];
                    break;
                



                default:
                    break;

            }
        }
    }
}
