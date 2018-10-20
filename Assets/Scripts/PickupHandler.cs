using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour {

    public GameObject player;

    public int normalAmmoAmount;
  
	// Use this for initialization
	void Start () {

        normalAmmoAmount = 20;

	}
	
	// Update is called once per frame
	void Update () {



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            player.GetComponent<PlayerHandler>().currentPlayerAmmo += normalAmmoAmount;
            Destroy(this.gameObject);
        }
    }
}
