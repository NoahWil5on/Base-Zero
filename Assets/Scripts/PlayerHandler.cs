using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    //To move player between scenes use "SceneManager.MoveGameObjectToScene(Gameobject, Sceneto);

    public int startingPlayerHealth = 1000;
    public int currentPlayerHealth;

    public int currentPlayScraps = 0;
    public int currentPlayerCash;

    public int currentPlayerAmmo;

	// Use this for initialization
	void Start () {

        currentPlayerCash = 0;
        currentPlayScraps = 0;

        //So player doesn't get destroyed on scene change
        DontDestroyOnLoad(this.gameObject);

        //Set starting health to 100 and ammo to 0
        currentPlayerHealth = startingPlayerHealth;
        currentPlayerAmmo = 0;
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(int damageAmount)
    {
        currentPlayerHealth -= damageAmount;
    }
}
