using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    //Main Shop Screen Array
    public GameObject categoryScreen;

    public GameObject[] weaponRefArray;

    public GameObject assaultRifleScreen;

	// Use this for initialization
	void Start () {

        categoryScreen.SetActive(true);
        assaultRifleScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    public void hideScreen(GameObject screenToHide)
    {
        screenToHide.SetActive(false);
    }
    public void unhideScreen(GameObject screenToUnhide)
    {
        screenToUnhide.SetActive(true);
    }
    public void hideAllWeapons()
    {
        for(int i = 0; i < weaponRefArray.Length; i++)
        {
            weaponRefArray[i].SetActive(false);
        }
    }
}
