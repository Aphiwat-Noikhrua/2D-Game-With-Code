using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private Animator anim;
    private Collider2D dimond;
    public AudioClip soundDimond;

    AudioSource audioSource;
    
    void Start()
    {
    anim = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
    dimond = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        audioSource.PlayOneShot(soundDimond, 1F);

        anim.SetBool("boom",true);
        Destroy(gameObject,0.3f); 
    }
}