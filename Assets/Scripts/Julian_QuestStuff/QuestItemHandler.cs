using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestItemHandler : MonoBehaviour {

    public GameObject associatedQuestObject;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            associatedQuestObject.GetComponent<Quest>().changeQuestStatus("Completed");
            Destroy(this.gameObject);
        }
    }
    
}
