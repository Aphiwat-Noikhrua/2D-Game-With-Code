using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
  public float speed = 5f;
  public float maxRight = 35f;
  public float maxLeft = 27f;
  bool moveRight = true;

  private Rigidbody2D rb;
  private Animator anim;

   void Start() 
  {
      rb = GetComponent<Rigidbody2D>();   
      anim = GetComponent<Animator>();
  }   


    void Update()
    {
        //cal direction
        if (transform.position.x < maxLeft)
        {
            //Debug.Log("position = "+transform.position.x);
            moveRight = true;
            
        }
        if (transform.position.x > maxRight)
        {
            //Debug.Log("position = "+transform.position.x);
            moveRight = false;          
        }
       
            
        //move
        if (moveRight)
        {
            rb.velocity = new Vector2((speed),(rb.velocity.y));
            transform.localScale = new Vector2(-1,1);
        }
        else
        {
            rb.velocity = new Vector2((speed*-1),(rb.velocity.y));
            transform.localScale = new Vector2(1,1);
        }
       
   
    }
}