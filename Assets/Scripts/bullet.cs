using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision objectWeHit)
    {
        if (objectWeHit.gameObject.CompareTag("Target"))
        {
            print("hit " + objectWeHit.gameObject.name + " !");

            Destroy(gameObject);
        }

        //if (objectWeHit.gameObject.CompareTag("Zombie"))
        //{
        //    print("hit " + objectWeHit.gameObject.name + " !");

        //    Destroy(gameObject);

        //    objectWeHit.gameObject.GetComponent<zombie>().TakeDamage(25);
        //}



    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
