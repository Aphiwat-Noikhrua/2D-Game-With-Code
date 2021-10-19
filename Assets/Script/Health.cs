using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Animator anim;
    private Collider2D cherry;
    public AudioClip soundCherrry;
   
    AudioSource audioSource;
    
    void Start()
    {
    anim = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
    cherry = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        audioSource.PlayOneShot(soundCherrry, 1F);

        anim.SetBool("boom",true);
        Destroy(gameObject,0.3f); 
    }
}
