using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    //To move player between scenes use "SceneManager.MoveGameObjectToScene(Gameobject, Sceneto);

    public int startingPlayerHealth = 1000;
    private int currentPlayerHealth;
    public GameObject gameManager;

	// Use this for initialization
	void Start () {

        //So player doesn't get destroyed on scene change
        DontDestroyOnLoad(this.gameObject);

        //Set starting health to 100 and ammo to 0
        currentPlayerHealth = startingPlayerHealth;
	}

    public int GetHealth(){
        return currentPlayerHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentPlayerHealth -= damageAmount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "NormalAmmo")
        {            
            gameManager.GetComponent<GameManager>().AddAmmo("AR", other.GetComponent<PickupHandler>().normalAmmoAmount);
            Destroy(other.gameObject);            
        }
        else if(other.gameObject.tag == "ScrapBox")
        {

            gameManager.GetComponent<GameManager>().AddScraps(other.GetComponent<PickupHandler>().scrapBoxAmount);
            Destroy(other.gameObject);            
        }
        else if (other.gameObject.tag == "SmallCash")
        {
            gameManager.GetComponent<GameManager>().AddCash(other.GetComponent<PickupHandler>().smallCashAmount);
            Destroy(other.gameObject);            
        }
    }
}
