using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    private int HP = 100;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            SoundManager.Instance.ZombieSoundsChannel.PlayOneShot(SoundManager.Instance.ZombieDeath);
            animator.SetTrigger("DIE1");
            StartCoroutine(DestroyGameObjectAfterDelay(2.5f));
        }
        else
        {
            //play hurt sound once
            SoundManager.Instance.ZombieSoundsChannel.PlayOneShot(SoundManager.Instance.ZombieHurt);
            animator.SetTrigger("DAMAGE");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyGameObjectAfterDelay(float delay)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delay);

        SoundManager.Instance.ZombieSoundsChannel.Stop();
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
