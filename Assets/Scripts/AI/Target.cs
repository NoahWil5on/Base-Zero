using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public float health = 50f;

    private GameObject player;
    private GameManager gm;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("gm");
        gm = player.GetComponent<GameManager>();
    }

    public void TakeDamage(float amount){
        health -= amount;

        if(health <= 0){
            gm.AddScraps(Random.Range(20, 30));
            gm.AddCash(Random.Range(20, 60));
            Destroy(gameObject);
        }
    }
}
