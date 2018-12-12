using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class arrowHandler : MonoBehaviour
{

    public GameObject goTarget;
    public GameObject controller;

    private GameObject mngrRef;

    private QuestManager qm;

    private bool flag = true;

    void Start()
    {
        mngrRef = GameObject.FindGameObjectWithTag("gm");
        qm = mngrRef.GetComponent<QuestManager>();
        
    }

    void Update()
    {
        
        //if (flag)
        //{
            onObjectiveChange();
        //    flag = false;
        //}

        //goTarget = GameObject.FindGameObjectWithTag("Heli2");
        Vector3 tmpVec = controller.transform.InverseTransformPoint(goTarget.transform.position);

        float angtoTar = Mathf.Atan2(tmpVec.x, tmpVec.z) * Mathf.Rad2Deg;
        angtoTar += 180.0f;
        this.transform.localEulerAngles = new Vector3(90, angtoTar, 0);
    }
    public void onObjectiveChange()
    {
        Scene curScene = SceneManager.GetActiveScene();
        string sceneName = curScene.name;

        if (sceneName == "HQ")
        {
            if (qm.sendCurQuestLocation() == "HQ")
            {
                switch (qm.sendCurQuestName())
                {
                   
                    case "Heli2":
                        goTarget = GameObject.FindGameObjectWithTag("Heli2");
                        break;
                  
                    case "Heli4":
                        goTarget = GameObject.FindGameObjectWithTag("Heli4");
                        break;
                    case "Heli5":
                        goTarget = GameObject.FindGameObjectWithTag("Heli5");
                        break;
                    case "Nuke1":
                        goTarget = GameObject.FindGameObjectWithTag("Nuke1");
                        break;
                    
                    case "Nuke3":
                        goTarget = GameObject.FindGameObjectWithTag("Nuke3");
                        break;
                   
                    case "Misc2":
                        goTarget = GameObject.FindGameObjectWithTag("Misc2");
                        break;
                    
                    case "Misc4":
                        goTarget = GameObject.FindGameObjectWithTag("Misc4");
                        break;
                    case "Misc5":
                        goTarget = GameObject.FindGameObjectWithTag("Misc5");
                        break;

                    case "Escape":
                        goTarget = GameObject.FindGameObjectWithTag("Escape");
                        break;

                    default:
                        break;

                }
               
            }
            else if (qm.sendCurQuestLocation() == "Trainyard")
            {
                goTarget = GameObject.FindGameObjectWithTag("HQtoTrainyard");
            }

        }
        else if(sceneName == "Trainyard")
        {
            if (qm.sendCurQuestLocation() == "Trainyard")
            {
                switch (qm.sendCurQuestName())
                {

                    case "Heli1":
                        goTarget = GameObject.FindGameObjectWithTag("Heli1");
                        break;

                    case "Heli3":
                        goTarget = GameObject.FindGameObjectWithTag("Heli3");
                        break;
                    
                    case "Nuke2":
                        goTarget = GameObject.FindGameObjectWithTag("Nuke2");
                        break;

                    case "Nuke4":
                        goTarget = GameObject.FindGameObjectWithTag("Nuke4");
                        break;
                    case "Nuke5":
                        goTarget = GameObject.FindGameObjectWithTag("Nuke5");
                        break;
                    case "Misc1":
                        goTarget = GameObject.FindGameObjectWithTag("Misc1");
                        break;

                    case "Misc3":
                        goTarget = GameObject.FindGameObjectWithTag("Misc3");
                        break;
                   
                    default:
                        break;

                }

            }
            else if (qm.sendCurQuestLocation() == "HQ")
            {
                goTarget = GameObject.FindGameObjectWithTag("TrainyardtoHQ");
            }
        }
    }

}

