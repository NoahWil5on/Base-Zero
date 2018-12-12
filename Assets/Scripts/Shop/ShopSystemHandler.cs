using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopSystemHandler : MonoBehaviour {
    
    public struct ShopWeapon
    {
        public bool stockUpgraded;
        public bool scopeUpgraded;
        public bool barrelUpgraded;
        public bool magazineUpgraded;
        public bool purchased;
        public string name;
    }

    public ShopManager shopRef;
    public int[] equippedWeapons = new int[3];
    public ShopWeapon[] weaponsList = new ShopWeapon[7];
    // Use this for initialization
    void Start () {
        
		if(SceneManager.GetActiveScene().name == "shoptest")
        {
            shopRef = GameObject.FindGameObjectWithTag("shopmanager").GetComponent<ShopManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateShop()
    {

    }

    void updateWeapons()
    {
        for(int i =0; i < weaponsList.Length; i++)
        {
            weaponsList[i].name = shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().name;
            weaponsList[i].magazineUpgraded = shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().magazineUpgraded;
            weaponsList[i].scopeUpgraded = shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().scopeUpgraded;
            weaponsList[i].stockUpgraded = shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().stockUpgraded;
            weaponsList[i].barrelUpgraded = shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().barrelUpgraded;
        }

        equippedWeapons[0] = shopRef.equippedWeapons[0].GetComponent<WeaponInfo>().wepIndex;
        equippedWeapons[1] = shopRef.equippedWeapons[1].GetComponent<WeaponInfo>().wepIndex;
        equippedWeapons[2] = shopRef.equippedWeapons[2].GetComponent<WeaponInfo>().wepIndex;
    }
}
