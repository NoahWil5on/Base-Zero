using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButton : MonoBehaviour {
    public int upgradeVal;
    public GameObject shopManager;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void unHideElement(GameObject element)
    {
        if(element != null)
        {
            element.SetActive(true);
        }
        
    }
    public void hideElement(GameObject element)
    {
        if (element != null)
        {
            element.SetActive(false);
        }
    }
    public void hideAllChildren(GameObject parentOfChildren)
    {
        foreach(Transform child in parentOfChildren.transform)
        {
            child.gameObject.SetActive(false);
            hideAllChildren(child.gameObject);
        }
    }
    public void unhideAllChildren(GameObject parentOfChildren)
    {
        foreach (Transform child in parentOfChildren.transform)
        {
            child.gameObject.SetActive(true);
            hideAllChildren(child.gameObject);
        }
    }

    public void purchaseUpgrade(GameObject weapon)
    {
        WeaponInfo weaponRef = weapon.GetComponent<WeaponInfo>();
        bool purchaseComplete = false;
        switch (upgradeVal)
        {
            case 1:
                if(shopManager.GetComponent<ShopManager>().scrap >= weaponRef.stockCost)
                {
                    shopManager.GetComponent<ShopManager>().scrap -= weaponRef.stockCost;
                    weaponRef.stockUpgraded = true;
                    weaponRef.stockUpgrade.SetActive(true);
                    if (weaponRef.stock != null)
                    {
                        weaponRef.stock.SetActive(false);
                    }
                    purchaseComplete = true;
                }
                break;
            case 2:
                if (weaponRef.scopeUpgrade != null && shopManager.GetComponent<ShopManager>().scrap >= weaponRef.scopeCost)
                {
                    shopManager.GetComponent<ShopManager>().scrap -= weaponRef.scopeCost;
                    weaponRef.scopeUpgraded = true;
                    weaponRef.scopeUpgrade.SetActive(true);
                    if (weaponRef.scope != null)
                    {
                        weaponRef.scope.SetActive(false);
                    }
                    purchaseComplete = true;
                }
                break;
            case 3:
                if (shopManager.GetComponent<ShopManager>().scrap >= weaponRef.barrelCost)
                {
                    shopManager.GetComponent<ShopManager>().scrap -= weaponRef.barrelCost;
                    weaponRef.barrelUpgraded = true;
                    weaponRef.barrelUpgrade.SetActive(true);
                    if (weaponRef.barrel != null)
                    {
                        weaponRef.barrel.SetActive(false);
                    }
                    purchaseComplete = true;
                }
                break;
            case 4:
                if (shopManager.GetComponent<ShopManager>().scrap >= weaponRef.magazineCost)
                {
                    shopManager.GetComponent<ShopManager>().scrap -= weaponRef.magazineCost;
                    weaponRef.magazineUpgraded = true;
                    weaponRef.magazineUpgrade.SetActive(true);
                    if (weaponRef.magazine != null)
                    {
                        weaponRef.magazine.SetActive(false);
                    }
                    purchaseComplete = true;
                }
                break;
            default:
                break;
        }
        if(purchaseComplete)
        {
            shopManager.GetComponent<ShopManager>().UpdateCashScrap();
            Destroy(gameObject);
        }
       
    }
}
