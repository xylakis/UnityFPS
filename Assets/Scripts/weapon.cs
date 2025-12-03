using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// taken from: https://www.youtube.com/watch?v=woXLV8cIe7s&list=PLtLToKUhgzwm1rZnTeWSRAyx9tl8VbGUE&index=4&ab_channel=Mike%27sCode


public class weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;

    // CREATE
    // public Animator animator;

    //WEAPON RELOAD 
    //public float reloadTime;
    //public int magazineSize, bulletsLeft;
    //private bool isReloading;

    // UI 
    public TextMeshProUGUI ammoDisplay;

    private void Awake()
    {
        //bulletsLeft = magazineSize;
    }

    private void Start()
    {
        //Ensure the Animator is assigned
        //if (animator == null)
        //{
        //    animator.GetComponent<Animator>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // Left mouse click 

        if (Input.GetKeyDown(KeyCode.Mouse0) /*&& bulletsLeft!=0*/ )
        {
            FireWeapon();
        }

        //if (Input.GetKeyDown(KeyCode.R) && bulletsLeft<magazineSize && isReloading==false)
        //{
        //    ReloadWeapon();
        //}
        //// check if ammoDisplay has been added in the Editor 
        //// and display it
        //if (ammoDisplay != null)
        //{
        //    ammoDisplay.text = $"{bulletsLeft}/{magazineSize}";

        //}

    }

    private void FireWeapon()
    {
        //decrease bullet counter everytime we shoot
        //bulletsLeft--;

        //animator.SetTrigger("RECOIL");

        //SoundManager.Instance.shootingSound.Play();

        //Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        
        // Shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(-bulletSpawn.right.normalized * bulletVelocity, ForceMode.Impulse);

        //Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

    }

    //private void ReloadWeapon()
    //{
    //    isReloading = true;
    //    SoundManager.Instance.reloadSound.Play();
    //    Invoke("ReloadCompleted", reloadTime);
    //}

    //we use coroutines 
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        //wait 3 seconds before destroying game object bullet
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    //private void ReloadCompleted()
    //{
    //    bulletsLeft = magazineSize;
    //    isReloading = false;
    //}




}
