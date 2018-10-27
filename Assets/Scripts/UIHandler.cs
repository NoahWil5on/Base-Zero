using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

    public GameObject player;
    public GameObject gameManager;
    private int playerHealth;
    private int playerAmmo;
    private int playerScraps;
    private int playerCash;

    public Text healthUIText;
    public Text ammoUIText;

    public GameObject resourceMenuBackground;
    public Text scrapsText;
    public Text cashText;

	// Use this for initialization
	void Start () {
        resourceMenuBackground.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.Tab))
        {
            resourceMenuBackground.SetActive(true);
        }
        else
        {
            resourceMenuBackground.SetActive(false);
        }
        playerAmmo = gameManager.GetComponent<GameManager>().CheckAmmo("AR");
        playerHealth = player.GetComponent<PlayerHandler>().GetHealth();;
        playerScraps = gameManager.GetComponent<GameManager>().GetPlayerScraps();
        playerCash = gameManager.GetComponent<GameManager>().GetPlayerCash();

        ammoUIText.text = (playerAmmo).ToString();
        healthUIText.text = (playerHealth / 10).ToString();
        scrapsText.text = (playerScraps).ToString();
        cashText.text = (playerCash).ToString();

	}
}
