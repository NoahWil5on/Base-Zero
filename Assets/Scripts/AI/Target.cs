using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public float health = 50f;

	
	public void TakeDamage(float amount){
        health -= amount;

        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
