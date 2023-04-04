using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public GameObject PausePanel;

    public static PlayerMovment instance;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public Animator anim;
    private SpriteRenderer Sprite;


   // [SerializeField] private Joystick joystick;
    [SerializeField] private LayerMask jumpableGround;


    private float dirx = 0f;
    public float WalkSpeed = 4f;
    public float JumpForce = 15f;

    private enum MovmentState {Idle, Running,Jumping,Leez,Telo }

    [SerializeField] private AudioSource JumpSoundEffect;
    float verticalmove;
    public bool isJumping;
    public int doubleJump = 2;
    private object collision;
    public bool Ispaused = false;
     void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();
       // anim = GetComponent<Animator>();
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isJumping = true;

    }

    // Update is called once per frame
    private void Update()
    {
        //Walk Methode
        dirx = 1f;
        rb.velocity = new Vector2(dirx * WalkSpeed, rb.velocity.y);
        //Jump Methode
        

       // verticalmove = joystick.Vertical;
       
        //This If For Double Jump if double jump bitwean 2 and 0
      //  if (doubleJump <= 2 && doubleJump >= 0)
      //  {
      //      isJumping = true;

      //      if (isJumping)
      //      {
      //          if (verticalmove >= 0.1f)
      //          {

      //              JumpSoundEffect.Play();
      //              rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                   

      //              doubleJump--;
     //           }
     //       }
     //   }

      //  if (doubleJump == 0)
     //   {
     //       isJumping = false;
     //       StartCoroutine(JumpAgain());
      //  }

        UpadateAnimationUpdate();
        


        }
    public void jump(float J)
    {
        // rb.velocity = new Vector2(rb.velocity.x, J);

        // Invoke("jump", 2f);
      //  if (doubleJump <= 2 && doubleJump >= 0)
       // {
            

            if (isJumping)
            {
               //if (verticalmove >= 0.1f)
                //{
                    
                    JumpSoundEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, J);
                    isJumping = false;
                    StartCoroutine(JumpAgain());


            //  doubleJump-=2;
            // }
        }
       // }


    }
    private void UpadateAnimationUpdate()
    {
        MovmentState state;

        if(dirx > 0f)
        {
            state = MovmentState.Idle;
            Sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovmentState.Idle;
            Sprite.flipX=true;
        }
        
            // if (Input.GetKey(KeyCode.LeftShift))
            // {
            // anim.SetBool("Running", true);
            // }
            // else if (Input.GetKeyUp(KeyCode.LeftShift))
            //   {
            //  anim.SetBool("Running", false);
            //   }

            if (rb.velocity.y > .1f)
        {
            state = MovmentState.Jumping;
        }
            
        

        
       // else if(rb.velocity.y < -0.1f)
      //  {
      //      state = MovmentState.Falling;
      //  }
        else
        {
            state = MovmentState.Idle;
        }

        anim.SetInteger("state", (int)state);
       
     }
    


    public bool isGrounded()
    {
       return  Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    IEnumerator JumpAgain()
    {
        yield return new WaitForSeconds(0.7f);
        isJumping=true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Chale")
        {
            anim.SetTrigger("TELOOO");
            Debug.Log("chale");
            WalkSpeed = 8f;
            Invoke("SpeedReset", 1.2f);

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "SpeedBoost")
        {
            anim.SetTrigger("RunFast");
            Debug.Log("SpeedBoost");
            WalkSpeed = 20f;
            Invoke("SpeedReset", 6f);

        }

    }
    
    public void SpeedReset()
    {
        WalkSpeed = 12f;
    }
    public void PauseGame()
    {
        if (!Ispaused)
        {
            Time.timeScale = 0;
            Ispaused = true;
            // PausePanel.SetActive(true);
        }
        else
        {
            Ispaused = false;
            Time.timeScale = 1;
          //  PausePanel.SetActive(false);

        }
        

    }
    public void Liz()
    {
      //  MovmentState state;
        anim.SetTrigger("Leez");
       
        Debug.Log("Liz");

    }
    public void SpeedBoost()
    {
     //   anim.SetTrigger("RunFast");
        Debug.Log("SpeedBoost");
        WalkSpeed = 20f;
        Invoke("SpeedReset", 2f);
    }
    

  
   

}
