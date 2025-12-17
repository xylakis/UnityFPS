using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newZombie : MonoBehaviour
{
    private int HP = 100;

    public bool isZombieDying = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
