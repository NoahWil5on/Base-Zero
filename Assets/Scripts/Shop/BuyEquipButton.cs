using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyEquipButton : MonoBehaviour {
    public GameObject attachmentList;
    public GameObject shopManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buyEquipWeapon(GameObject weapon)
    {
        WeaponInfo weaponRef = weapon.GetComponent<WeaponInfo>();

        if (!weaponRef.purchased)
        {
            if (shopManager.GetComponent<ShopManager>().cash >= weaponRef.weaponCost)
            {
                shopManager.GetComponent<ShopManager>().cash -= weaponRef.weaponCost;
                weaponRef.purchased = true;
                attachmentList.SetActive(true);
                shopManager.GetComponent<ShopManager>().UpdateCashScrap();
                shopManager.GetComponent<ShopManager>().EnableEquipSlots();
                Destroy(gameObject);
            }
        }
    }
}
