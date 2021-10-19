using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    //set
  public float speed = 1f;
  public float jump = 6f;


  bool moveRight = true;
  public float maxRight = 7.7f;
  public float maxLeft = 5.7f;
  
  bool moveUp = true;
  public float maxDown = -3.6f;

  private Rigidbody2D rb;
  private Animator animFrog;

  void Start() 
  {
      rb = GetComponent<Rigidbody2D>();   
      animFrog = GetComponent<Animator>();
      
  }   

    void Update()
    {
        
        if(transform.position.y > maxDown)
        {
            animFrog.SetBool("Jumping",true);
        }
        
        if(transform.position.y < maxDown)
            {
            animFrog.SetBool("Idle",true);
            animFrog.SetBool("Jumping",false);
            }
        }

    
    private void Move()
    {
        //cal direction
        if (transform.position.x < maxLeft)
        {
            // Debug.Log("position = "+transform.position.x);
            moveRight = true;
            
        }
        if (transform.position.x > maxRight)
        {
            // Debug.Log("position = "+transform.position.x);
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

