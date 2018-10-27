using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour {

    public GameObject enemyType;
    public float timeBetweenSpawns = 2f;

    private bool coroutineFired = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!coroutineFired)
        {
            coroutineFired = true;
            StartCoroutine(Spawn());

        }

    }
    IEnumerator Spawn()
    {
        Instantiate(enemyType, transform.position + transform.forward, transform.rotation);
        yield return new WaitForSeconds(timeBetweenSpawns);
        Debug.Log("lalalala");
        coroutineFired = false;
    }
}
