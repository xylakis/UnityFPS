using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{

    //private NavMeshAgent agent;
    private Animator animator;

    //private GameObject enemy;
    private bool isZombieDying;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isZombieDying = GetComponent<newZombie>().isZombieDying;

        if (isZombieDying == true)
        {
            GetComponent<NavMeshAgent>().speed = 0;
        }
        
    }
}
