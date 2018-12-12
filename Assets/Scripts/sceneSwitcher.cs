using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneSwitcher : MonoBehaviour {

    private GameObject arrow;
    private arrowHandler arrowScr;
	// Use this for initialization
	void Start () {
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        arrowScr = arrow.GetComponent<arrowHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        arrowScr = arrow.GetComponent<arrowHandler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Scene curScene = SceneManager.GetActiveScene();
            string sceneName = curScene.name;


            if(sceneName == "HQ")
            {
                if(this.gameObject.tag == "HQtoTrainyard")
                {
                    SceneManager.LoadScene(2);
                   // arrowScr.onObjectiveChange();
                    SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("Player"), SceneManager.GetSceneByBuildIndex(2));

                }
            }
            else if(sceneName == "Trainyard")
            {
                if (this.gameObject.tag == "TrainyardtoHQ")
                {
                    SceneManager.LoadScene(1);
                    //arrowScr.onObjectiveChange();
                    SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("Player"), SceneManager.GetSceneByBuildIndex(1));
                }
            }
        }
    }
}
