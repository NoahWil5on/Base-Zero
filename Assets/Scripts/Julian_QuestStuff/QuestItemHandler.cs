using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestItemHandler : MonoBehaviour {

    private GameObject associatedQuestObject;
    private GameObject mngrRef;

    private QuestManager qm;

    private bool flag;
	// Use this for initialization
	void Start () {

        flag = true;
        mngrRef = GameObject.FindGameObjectWithTag("gm");
        qm = mngrRef.GetComponent<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (flag)
        {
            findAssociatedGameObject();
            flag = false;
        }
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == qm.sendCurQuestName())
        {
            if (other.gameObject.tag == "Player")
            {
                associatedQuestObject.GetComponent<Quest>().changeQuestStatus("Completed");
                Destroy(this.gameObject);
                findAssociatedGameObject();
            }

        }
       
    }
    public void findAssociatedGameObject()
    {
        associatedQuestObject = qm.returnQuestGO(this.gameObject.tag);
    }
    
}
