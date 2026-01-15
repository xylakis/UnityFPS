using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator animator;

    

    //private GameObject enemy;
    private bool isZombieDying;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

        agent.destination = player.transform.position;

        if (distanceFromPlayer < 2.5f)
        {
            animator.SetBool("isAttacking", true);
            print("Atacking Melee");
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        isZombieDying = GetComponent<newZombie>().isZombieDying;

        if (isZombieDying == true)
        {
            GetComponent<NavMeshAgent>().speed = 0;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);
    }
}
