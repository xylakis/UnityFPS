using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newZombie : MonoBehaviour
{
    private int HP = 100;

    public bool isZombieDying = false;

    public Animator animator;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //player = GameObject.FindGameObjectWithTag("Character").transform;
    }

    // Update is called once per frame
    void Update(){
        
        player = GetComponent<EnemyNavScript>().player;

        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceFromPlayer < 2.5f)
        {
            //animator.SetBool("isAttacking", true);
            print("Atacking Melee");
        }
        else
        {
            //animator.SetBool("isAttacking", false);
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
