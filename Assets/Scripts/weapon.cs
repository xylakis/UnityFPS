using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// taken from: https://www.youtube.com/watch?v=woXLV8cIe7s&list=PLtLToKUhgzwm1rZnTeWSRAyx9tl8VbGUE&index=4&ab_channel=Mike%27sCode


public class weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;

    //CREATE
    public Animator animator;

    private void Start()
    {
        //Ensure the Animator is assigned
        if (animator == null)
        {
            animator.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Left mouse click 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        animator.SetTrigger("RECOIL");

        SoundManager.Instance.shootingSound.Play();

        //Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        
        // Shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(-bulletSpawn.right.normalized * bulletVelocity, ForceMode.Impulse);

        //Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

    }

    //we use coroutines 
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        //wait 3 seconds before destroying game object bullet
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }




}
