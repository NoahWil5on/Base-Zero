﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    //To move player between scenes use "SceneManager.MoveGameObjectToScene(Gameobject, Sceneto);

    private float startingPlayerHealth = 100;
    public float currentPlayerHealth;

    
    public int currentPlayerAmmo;

	// Use this for initialization
	void Start () {

        //So player doesn't get destroyed on scene change
        DontDestroyOnLoad(this.gameObject);

        //Set starting health to 100 and ammo to 0
        currentPlayerHealth = startingPlayerHealth;
        currentPlayerAmmo = 0;
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(float damageAmount)
    {
        currentPlayerHealth -= damageAmount;
    }
}
