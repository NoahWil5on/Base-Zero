using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour {

    public GameObject playerRef;

    public GameObject enemyType;
    public float timeBetweenSpawns = 2f;

    private bool coroutineFired = false;

    public bool spawnLimitedEnemies = false;
    public int enemiesToSpawn;
	// Use this for initialization
	void Start () {

        playerRef = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
        if (!coroutineFired)
        {
            coroutineFired = true;

            if (!spawnLimitedEnemies)
            {

                StartCoroutine(Spawn());
            }
            else if (spawnLimitedEnemies)
            {
                StartCoroutine(SpawnLimited());
            }

        }

    }
    IEnumerator Spawn()
    {
       

            if(Vector3.Dot(playerRef.transform.forward, (this.transform.position - playerRef.transform.position).normalized) < 0f)
            {
                Instantiate(enemyType, transform.position + transform.forward, transform.rotation);
                yield return new WaitForSeconds(timeBetweenSpawns);
                Debug.Log("lalalala");
                coroutineFired = false;
            }
            else
            {
                Debug.Log("FACING!!!");
                coroutineFired = false;

            }
        
       
    }
    IEnumerator SpawnLimited()
    {
        
        for(int i = 0; i < enemiesToSpawn; i++)
        {

            Instantiate(enemyType, transform.position + transform.forward, transform.rotation);
            yield return new WaitForSeconds(timeBetweenSpawns);
            //Debug.Log("3hunnit");
        }
        
            
        
    }
}
