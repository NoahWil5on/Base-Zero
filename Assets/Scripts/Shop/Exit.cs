using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void exitShop()
    {
        GameObject.FindGameObjectWithTag("gm").GetComponent<ShopSystemHandler>().updateWeapons();
        SceneManager.LoadScene("HQ");

    }
}
