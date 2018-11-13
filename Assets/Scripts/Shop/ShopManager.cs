using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    //Main Shop Screen Array
    public GameObject categoryScreen;

    public GameObject statFlavorScreen;

    public GameObject assaultRifleScreen;

	// Use this for initialization
	void Start () {

        statFlavorScreen.SetActive(false);
        categoryScreen.SetActive(true);
        assaultRifleScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if(assaultRifleScreen.activeSelf == true)
        {
            statFlavorScreen.SetActive(true);
        }
		
	}

    public void hideScreen(GameObject screenToHide)
    {
        screenToHide.SetActive(false);
    }
    public void unhideScreen(GameObject screenToUnhide)
    {
        screenToUnhide.SetActive(true);
    }
}
