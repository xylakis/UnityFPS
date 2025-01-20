using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; set; }
    
    public AudioSource shootingSound;
    public AudioSource reloadSound;
    
    public AudioClip ZombieHurt;
    public AudioClip ZombieDeath;

    public AudioSource ZombieSoundsChannel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
