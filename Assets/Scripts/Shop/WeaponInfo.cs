using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour {
    public GameObject stock;
    public GameObject scope;
    public GameObject barrel;
    public GameObject magazine;
    public GameObject stockUpgrade;
    public GameObject scopeUpgrade;
    public GameObject barrelUpgrade;
    public GameObject magazineUpgrade;
    public bool stockUpgraded = false;

	// Use this for initialization
	void Start () {
        stockUpgrade.SetActive(false);
        scopeUpgrade.SetActive(false);
        barrelUpgrade.SetActive(false);
        magazineUpgrade.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hideAttachment(GameObject attachmentToHide)
    {
        attachmentToHide.SetActive(false);
    }
    public void unhideAttachment(GameObject attachmentToUnHide)
    {
        attachmentToUnHide.SetActive(true);
    }

    public void purchaseAttachment(string attachment)
    {
        switch (attachment)
        {
            case "stock":
                stockUpgraded = true;                  
                break;
            default:
                break;
        }
    }

}
