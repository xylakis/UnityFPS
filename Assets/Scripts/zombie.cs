using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class zombie : MonoBehaviour
{
    private int HP = 100;
    private Animator animator;

    public bool isZombieDying = false;
    //public bool IsZombieDead = false;

    Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Character").transform;
    
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0 && isZombieDying == false)
        {
            isZombieDying = true;
            SoundManager.Instance.ZombieSoundsChannel.PlayOneShot(SoundManager.Instance.ZombieDeath);
            animator.SetTrigger("DIE1");
            StartCoroutine(DestroyGameObjectAfterDelay(2.5f));
        }
        else if (HP>0 && isZombieDying == false)
        {
            //play hurt sound once
            SoundManager.Instance.ZombieSoundsChannel.PlayOneShot(SoundManager.Instance.ZombieHurt);
            animator.SetTrigger("DAMAGE");
        }
    }
    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceFromPlayer < 2.5f) {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);
    }

    IEnumerator DestroyGameObjectAfterDelay(float delay)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delay);

        SoundManager.Instance.ZombieSoundsChannel.Stop();
        // Destroy the GameObject this script is attached to
        // Destroy(gameObject);
    }
}
