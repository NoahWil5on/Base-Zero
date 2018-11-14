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

    public float wanderRadius;
    public float wanderTimer;

    private float wanderTime;
    private float timer;
    
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 200;
    public bool playerInRange;

    public float distanceToSeekPlayer = 20f;
    

    private void Start()
    {
        wanderTime = wanderTimer;
        player = GameObject.FindWithTag("Player");
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
    public static Vector3 randomWanderDirection(Vector3 origin, float dist, int layer)
    {
        Vector3 randDir = Random.insideUnitSphere * dist;

        randDir += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, dist, layer);

        return navHit.position;
    }
    void Update () {

        float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        int playerHealth = player.GetComponent<PlayerHandler>().GetHealth();

        wanderTime += Time.deltaTime;
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
       
        if(distanceToPlayer > distanceToSeekPlayer)
        {

           if(wanderTime >= wanderTimer)
            {

                Vector3 newDir = randomWanderDirection(transform.position, wanderRadius, 1);
                zombie.SetDestination(newDir);
                wanderTime = 0;
            }
        }
        else if(distanceToPlayer < distanceToSeekPlayer)
        {

            zombie.SetDestination(player.transform.localPosition);
        }
        
	}
    private void Attack()
    {
        if(player.GetComponent<PlayerHandler>().GetHealth() > 0)
        {
            player.GetComponent<PlayerHandler>().TakeDamage(attackDamage);
        }
    }
   
}
