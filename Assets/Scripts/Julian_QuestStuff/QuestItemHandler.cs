using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestItemHandler : MonoBehaviour {

    public GameObject associatedQuestObject;
    private GameObject mngrRef;

    private QuestManager qm;

	// Use this for initialization
	void Start () {

        mngrRef = GameObject.FindGameObjectWithTag("gm");
        qm = mngrRef.GetComponent<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {

		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == qm.sendCurQuestName())
        {
            if (other.gameObject.tag == "Player")
            {
                associatedQuestObject.GetComponent<Quest>().changeQuestStatus("Completed");
                Destroy(this.gameObject);
            }

        }
       
    }
    
}
