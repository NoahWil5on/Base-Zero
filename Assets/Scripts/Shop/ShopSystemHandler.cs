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
    void awake () {        
		if(SceneManager.GetActiveScene().name == "shoptest")
        {
            shopRef = GameObject.FindGameObjectWithTag("shopmanager").GetComponent<ShopManager>();
            
            updateWeapons();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateShop()
    {
        for(int i = 0; i < weaponsList.Length; i++)
        {
            if (weaponsList[i].purchased)
            {
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().purchased = true;
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().WeaponAttachments.SetActive(true);
                if(shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().purchaseButton != null)
                {
                    Destroy(shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().purchaseButton);
                }
                
            }
            if (weaponsList[i].stockUpgraded)
            {
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().stockUpgraded = true;
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().stock.SetActive(false);
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().stockUpgrade.SetActive(true);
                Destroy(shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().stockButton);
            }
            if (weaponsList[i].scopeUpgraded)
            {
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().scopeUpgraded = true;
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().scope.SetActive(false);
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().scopeUpgrade.SetActive(true);
                Destroy(shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().scopeButton);
            }
            if (weaponsList[i].magazineUpgraded)
            {
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().magazineUpgraded = true;
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().magazine.SetActive(false);
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().magazineUpgrade.SetActive(true);
                Destroy(shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().magazineButton);
            }
            if (weaponsList[i].barrelUpgraded)
            {
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().barrelUpgraded = true;
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().barrel.SetActive(false);
                shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().barrelUpgrade.SetActive(true);
                Destroy(shopRef.weaponRefArray[i].GetComponent<WeaponInfo>().barrelButton);
            }
        }
    }

    public void updateWeapons()
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
