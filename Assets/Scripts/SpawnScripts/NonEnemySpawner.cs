using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonEnemySpawner : MonoBehaviour {

    public GameObject prefabToSpawn;

    private bool spawnFlag = true;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        if (spawnFlag)
        {
            Instantiate(prefabToSpawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
            spawnFlag = false;
        }


    }
}
