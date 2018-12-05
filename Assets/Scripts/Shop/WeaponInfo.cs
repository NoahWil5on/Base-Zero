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

    



}
