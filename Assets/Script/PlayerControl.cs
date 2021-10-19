using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
//player set
  private Rigidbody2D rb;
  private Animator anim;

  public float speed = 10f;
  public float jump = 20f;
  public int countJump = 0;
  public int levelnow = 1;
  
  //health set
  public int scoreHealth = 3;
  public Text scoreTextHealth;
  private string scenceWhenGameOver = "-GameOver";

  //gem set 
   private int scoreGem = 0;
   public Text scoreTextGem;
   private int gemCount;
   AudioSource audioSource;

   //victory set
   private string scenceWhenVictory = "-Victory";
   public AudioClip soundVictory;

   //Death set
   public AudioClip soundGameOver;



  private void Start() 
  {
      rb = GetComponent<Rigidbody2D>();   
      anim = GetComponent<Animator>();
      
      //UI gem score
      gemCount = GameObject.FindGameObjectsWithTag("gem").Length;
      scoreTextGem.text = "Gem = "+scoreGem +"/"+gemCount;

      //victory sound
      audioSource = GetComponent<AudioSource>();
  }   
  
   
    private void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        
        //move left
        if(direction<0)
        {
           rb.velocity = new Vector2((speed*-1),rb.velocity.y);
           transform.localScale = new Vector2(-1,1);
           anim.SetBool("running",true);
        }
        //move right  
        else if(direction>0)
        {
           rb.velocity = new Vector2(speed,rb.velocity.y);
           transform.localScale = new Vector2(1,1);
           anim.SetBool("running",true);
        }
         //not move
        else
        {
            anim.SetBool("running",false);
        }
        
        //jump
        if(Input.GetButtonDown("Jump"))
        {
           //check count jump before jumping
          if(countJump<1)
           {
           rb.velocity = new Vector2(rb.velocity.x,jump);
           anim.SetBool("jump",true);
           countJump++;
           }
        }
        //not jump
        else
        {
           anim.SetBool("jump",false);
        }
      //HP=0,restart
      if(scoreHealth==0)
      {
         SceneManager.LoadScene(levelnow+scenceWhenGameOver);
      }

    }

   //Enemy hit
    void OnCollisionEnter2D(Collision2D coll) 
    {
      if(coll.gameObject.tag.Equals("Enemy"))  
      {
         //Debug.Log("Enemy Hit");
         rb.velocity = new Vector2(rb.velocity.x,jump);
         anim.SetBool("hurt",true);
         
         scoreHealth--;
         scoreTextHealth.text = "Health = "+ scoreHealth;
      }
      else
      {
       anim.SetBool("jump",false);
       countJump = 0;
       anim.SetBool("hurt",false);
      }

    }

    void OnTriggerEnter2D(Collider2D target) 
    {
      //Debug.Log(target.gameObject.tag);
      
      //cherry zone
      if(target.gameObject.tag.Equals("cherry"))
      {
        scoreHealth++;
        scoreTextHealth.text = "Health = "+ scoreHealth;
      }
      
      //gem zone
      if(target.gameObject.tag.Equals("gem"))
      {
        scoreGem++;
        scoreTextGem.text = "Gem = "+ scoreGem +"/"+gemCount;
      }

      //victory zone
      if(target.gameObject.tag.Equals("VictoryZone")&&(scoreGem>=gemCount))
      {
         anim.SetBool("win",true);
         audioSource.PlayOneShot(soundVictory, 1F);  
         StartCoroutine(VictoryMenu());
      }

      //Death zone
      if(target.gameObject.tag.Equals("DeathZone"))
      {
      //Debug.Log("Death Zone");
         anim.SetBool("hurt",true);
         audioSource.PlayOneShot(soundGameOver, 1F);
         StartCoroutine(GameOverMenu());
         
      }
    }


//delay change scene victory
       IEnumerator VictoryMenu()
    {
        yield return new WaitForSeconds(0.4f);
         SceneManager.LoadScene(levelnow+scenceWhenVictory);
        
    }

//delay change scene gameover
       IEnumerator GameOverMenu()
    {
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(levelnow+scenceWhenGameOver);
    }


}
