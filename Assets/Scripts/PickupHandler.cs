using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour {

    public GameObject player;

    public int normalAmmoAmount;
    public int scrapBoxAmount;
    public int smallCashAmount;
    public string ammoType;

	// Use this for initialization
	void Start () {

        normalAmmoAmount = 20;
        scrapBoxAmount = 5;
        smallCashAmount = 10;
        player = GameObject.FindWithTag("Player");

	}
}
