using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
//set
  public float speed = 5f;
  public float jump = 5f;

  bool moveRight = true;
  public float maxRight = 45f;
  public float maxLeft = 35f;
  
  bool moveUp = true;
  public float maxDown = 0.2f;

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
            moveRight = true;
            //Debug.Log("position = "+transform.position.x);
        }
        if (transform.position.x > maxRight)
        {
            moveRight = false;  
            //Debug.Log("position = "+transform.position.x);        
        }
        
        //move
        if (moveRight)
        {
            rb.velocity = new Vector2((speed),rb.velocity.y);
            transform.localScale = new Vector2(-1,1);
        }
        else
        {
            rb.velocity = new Vector2((speed*-1),rb.velocity.y);
            transform.localScale = new Vector2(1,1);
        }
        
        //cal up-down
        if (transform.position.y < maxDown)
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
        }

        //up-down
        if (moveUp)
        {
            rb.velocity = new Vector2(rb.velocity.x,jump);
          }

    }
}
