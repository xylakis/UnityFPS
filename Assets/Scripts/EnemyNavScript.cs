using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{
    public Transform player; 
    private NavMeshAgent agent;

    //private GameObject enemy;
    public bool isZombieDying;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;

        // Find the Zombie GameObject
        GameObject zombie = GameObject.FindWithTag("Zombie");

        isZombieDying = zombie.GetComponent<zombie>().isZombieDying;

        if (isZombieDying == true)
        {
            GetComponent<NavMeshAgent>().speed = 0;
        }
        
    }
}
