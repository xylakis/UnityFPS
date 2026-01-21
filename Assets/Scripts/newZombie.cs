using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class newZombie : MonoBehaviour
{
    public int HP = 100;

    public bool isZombieDying = false;

    public Animator animator;

    private Transform player;

    private NavMeshAgent agent;

    private float attackTimer = 0f; // Timer to track attack duration
    public float damageInterval = 2f; // Damage interval in seconds
    public int damageAmount = 10; // Damage per interval

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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

            // Increment the timer
            attackTimer += Time.deltaTime;

            // Apply damage if the timer exceeds the damage interval and the Zombie is not Dead
            if (attackTimer >= damageInterval && HP > 0)
            {
                player.GetComponent<Player>().playerHP -= damageAmount;
                //Debug.Log($"Player HP: {playerHP}");
                attackTimer = 0f; // Reset the timer
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
            attackTimer = 0f;
        }

    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);
    }

    public void TakeDamage(int damageAmount)
    {
        HP -=damageAmount;

        if(HP <= 0 && isZombieDying == false)
        {
            isZombieDying = true;
            animator.SetTrigger("DIE");
            StartCoroutine(DestroyGameObjectWithDelay(3.5f));
        }
        else if (HP > 0 && isZombieDying == false)
        {
            //play hurt sound once
            //SoundManager.Instance.ZombieSoundsChannel.PlayOneShot(SoundManager.Instance.ZombieHurt);
            animator.SetTrigger("DAMAGE");
        }

    }

    IEnumerator DestroyGameObjectWithDelay(float delay)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delay);

        //SoundManager.Instance.ZombieSoundsChannel.Stop();
        // Destroy the GameObject this script is attached to
        // Destroy(gameObject);
    }
}
