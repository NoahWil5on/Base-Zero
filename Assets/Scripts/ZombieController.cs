using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Characters.FirstPerson;

using UnityEngine.AI;

public class ZombieController : MonoBehaviour {

    public GameObject player;
    public NavMeshAgent zombie;

    
    
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 200;
    public bool playerInRange;
    public float timer;

    private void Start()
    {
        
        zombie.stoppingDistance = 2f;
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }
    void Update () {

        int playerHealth = player.GetComponent<PlayerHandler>().currentPlayerHealth;

        
        timer += Time.deltaTime;

        if (playerInRange)
        {
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 2.5f;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 5f;

        }
        else
        {
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 5f;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 10f;
        }
        if (timer >= timeBetweenAttacks && playerInRange && playerHealth > 0)
        {

            Attack();
            Debug.Log("Zombie Attack");
            timer = 0f;
        }
       // player.GetComponent<PlayerHandler>().TakeDamage(100f);       
        zombie.SetDestination(player.transform.localPosition);
	}
    private void Attack()
    {
        if(player.GetComponent<PlayerHandler>().currentPlayerHealth > 0)
        {
            player.GetComponent<PlayerHandler>().TakeDamage(attackDamage);
        }
    }
}
