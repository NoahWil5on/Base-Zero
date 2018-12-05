using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipWeapon : MonoBehaviour {
    public ShopManager shopManager;
    public GameObject weaponSlot;
    public int wepIndex;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void equipWeapon()
    {        
        shopManager.equippedWeapons[wepIndex] = shopManager.currentWeapon;
        weaponSlot.GetComponentInChildren<Text>().text = shopManager.currentWeapon.GetComponent<WeaponInfo>().name;
        shopManager.ToggleEquips();
    }
}
