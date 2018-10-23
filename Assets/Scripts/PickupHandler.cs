using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour {

    public GameObject player;

    public int normalAmmoAmount;
    public int scrapBoxAmount;
    public int smallCashAmount;

	// Use this for initialization
	void Start () {

        normalAmmoAmount = 20;
        scrapBoxAmount = 5;
        smallCashAmount = 10;
        player = GameObject.FindWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {



    }
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "NormalAmmo")
        {
            if(other.gameObject.tag == "Player")
            {
            
                player.GetComponent<PlayerHandler>().currentPlayerAmmo += normalAmmoAmount;
                Destroy(this.gameObject);
            }
        }
        else if(this.gameObject.tag == "ScrapBox")
        {
            if (other.gameObject.tag == "Player")
            {

                player.GetComponent<PlayerHandler>().currentPlayScraps += scrapBoxAmount;
                Destroy(this.gameObject);
            }
        }
        else if (this.gameObject.tag == "SmallCash")
        {
            if (other.gameObject.tag == "Player")
            {

                player.GetComponent<PlayerHandler>().currentPlayerCash += smallCashAmount;
                Destroy(this.gameObject);
            }
        }
    }
}
