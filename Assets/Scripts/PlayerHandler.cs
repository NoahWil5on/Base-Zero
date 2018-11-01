using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    //To move player between scenes use "SceneManager.MoveGameObjectToScene(Gameobject, Sceneto);

    public int startingPlayerHealth = 1000;
    private int currentPlayerHealth;
    public GameObject gameManager;
    public GameObject[] playerWeapons = new GameObject[3];
    public int currentWeapon = 0;

    // Use this for initialization



    //QUEST STUFF

	void Start () {
        for(int i = 0; i < playerWeapons.Length; i++){
            if(!playerWeapons[i]) continue;
            playerWeapons[i].SetActive(false);
        }
        playerWeapons[currentWeapon].SetActive(true);

        //So player doesn't get destroyed on scene change
        DontDestroyOnLoad(this.gameObject);

        //Set starting health to 100 and ammo to 0
        currentPlayerHealth = startingPlayerHealth;
	}
    void Update(){
        if(Input.GetKeyDown("1")){
            SwitchWeapon(0);
        }else if(Input.GetKeyDown("2")){
            SwitchWeapon(1);
        }else if(Input.GetKeyDown("3")){
            SwitchWeapon(2);
        }
    }
    private void SwitchWeapon(int weaponNumber){
        if(currentWeapon == weaponNumber ||
        !playerWeapons[weaponNumber]) return;

        playerWeapons[currentWeapon].SetActive(false);
        currentWeapon = weaponNumber;
        playerWeapons[currentWeapon].SetActive(true);
    }
    public int GetHealth(){
        return currentPlayerHealth;
    }
    public Transform getPlayerPosition()
    {
        return this.transform;
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
