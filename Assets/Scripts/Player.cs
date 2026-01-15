using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int playerHP = 100; // Initial HP of the player
    private float attackTimer = 0f; // Timer to track attack duration
    public float damageInterval = 2f; // Damage interval in seconds
    public int damageAmount = 10; // Damage per interval

    public Material bloodMaterial ;

    // UI 
    public TextMeshProUGUI hpDisplay;

    //public TextMeshProUGUI diedDisplay;

    void Update()
    {
        // Find the Zombie GameObject
        GameObject zombie = GameObject.FindWithTag("Zombie");

        if (hpDisplay != null)
        {
            hpDisplay.text = $"{playerHP}";
        }

        //if (playerHP<0)
        //{
        //    diedDisplay.SetActive(true);
        //    Invoke("ChangeToMain", reloadTime);
        //}


        if (zombie != null)
        {
            // Get the Animator component from the Zombie GameObject
            Animator animator = zombie.GetComponent<Animator>();

            if (animator != null)
            {
                // Check if the zombie is attacking
                bool isAttacking = animator.GetBool("isAttacking");

                if (isAttacking)
                {
                    // Increment the timer
                    attackTimer += Time.deltaTime;

                    // Apply damage if the timer exceeds the damage interval
                    if (attackTimer >= damageInterval)
                    {
                        playerHP -= damageAmount;
                        //Debug.Log($"Player HP: {playerHP}");
                        attackTimer = 0f; // Reset the timer

                        //Get the current color
                        Color color = bloodMaterial.color;

                        //Increase the alpha by 100 %
                       color.a = 1f;


                        //Apply the updated color back to the material
                        bloodMaterial.color = color;
                    }
                }
                else
                {
                    // Reset the timer if the zombie is not attacking
                    attackTimer = 0f;

                    // Get the current color
                    Color color = bloodMaterial.color;

                    if (color.a > 0)
                    {
                        // Increase the alpha by 100%
                        color.a -= 0.01f;

                        // Apply the updated color back to the material
                        bloodMaterial.color = color;
                    }


                }
            }
            else
            {
                Debug.LogWarning("No Animator component found on the Zombie.");
            }
        }
        else
        {
            Debug.LogWarning("No GameObject with tag 'Zombie' found.");
        }

        // Check if the player HP reaches zero
        if (playerHP <= 0)
        {
            Debug.Log("Player is dead!");
            // Optionally, trigger death logic here

            // Unlock the cursor
            Cursor.lockState = CursorLockMode.None;

            // Make the cursor visible
            Cursor.visible = true;

            //diedDisplay.SetActive(true);
            //diedDisplay.meshRenderer.enabled = true;
            Invoke("ChangeToMain", 2f);
        }

    }

    private void ChangeToMain()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
