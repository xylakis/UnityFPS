using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{
    public Transform player; 
    private NavMeshAgent agent;

    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Find the Zombie GameObject
        GameObject zombie = GameObject.FindWithTag("Zombie");
        bool isZombieDying = zombie.GetComponent<zombie>.
        agent.destination = player.position;
    }
}
