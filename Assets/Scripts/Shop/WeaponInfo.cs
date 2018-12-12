using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour {


    public GameObject stock;
    public GameObject scope;
    public GameObject barrel;
    public GameObject magazine;
    public GameObject stockUpgrade;
    public GameObject scopeUpgrade;
    public GameObject barrelUpgrade;
    public GameObject magazineUpgrade;
    public GameObject stockButton;
    public GameObject scopeButton;
    public GameObject barrelButton;
    public GameObject magazineButton;
    public GameObject WeaponComponents;
    public GameObject WeaponAttachments;
    public GameObject purchaseButton;
    public bool stockUpgraded = false;
    public bool scopeUpgraded = false;
    public bool barrelUpgraded = false;
    public bool magazineUpgraded = false;
    public int stockCost = 150;
    public int scopeCost = 250;
    public int barrelCost = 150;
    public int magazineCost = 300;
    public int weaponCost = 1200;
    public bool purchased = false;
    public string name;
    public int wepIndex;
    // Use this for initialization
    void Start () {
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

    public void loadPurchase()
    {
        purchased = true;
        Destroy(purchaseButton);
    }

    



}
