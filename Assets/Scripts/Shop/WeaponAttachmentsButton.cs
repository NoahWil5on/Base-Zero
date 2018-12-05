using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachmentsButton : MonoBehaviour {
    public GameObject weapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void unHideElement(GameObject element)
    {
        if (weapon.GetComponent<WeaponInfo>().purchased)
        {
            element.SetActive(true);
        }
        
    }
    public void hideElement(GameObject element)
    {
        element.SetActive(false);
    }

    public void setCurrentWeapon(GameObject shopManager)
    {
        shopManager.GetComponent<ShopManager>().currentWeapon = weapon;
        if (weapon.GetComponent<WeaponInfo>().purchased)
        {
            shopManager.GetComponent<ShopManager>().CheckWeaponSlots();
        }
    }
}
