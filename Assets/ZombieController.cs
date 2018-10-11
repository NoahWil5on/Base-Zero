using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {

    public GameObject player;
    public NavMeshAgent zombie;

	// Update is called once per frame
	void Update () {

        zombie.SetDestination(player.transform.localPosition);
	}
}
