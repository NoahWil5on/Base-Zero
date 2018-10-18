using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

    public GameObject player;
    private int playerHealth;

    public Text healthUIText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        playerHealth = player.GetComponent<PlayerHandler>().currentPlayerHealth;
        healthUIText.text = (playerHealth / 10).ToString();
	}
}
