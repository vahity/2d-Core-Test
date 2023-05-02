using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    
    public static int x = 0;
    public int x12 = 0;
    public GameObject Sefid, Zard, Ghermez, BulletWarning;
    public bool Tello;
    public static bool Boost=false;
    int decreaseAmount = 1;

    // public GameObject[] shirtList;

    public GameObject PausePanel;

    public static PlayerMovment instance;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public Animator anim;
    private SpriteRenderer Sprite;


   // [SerializeField] private Joystick joystick;
    [SerializeField] private LayerMask jumpableGround;


    private float dirx = 0f;
    public  static float WalkSpeed = 12f;
    public float JumpForce = 15f;

    public enum MovmentState { Running, Jumping, Telo, Leez, Idle, BARGH }

    [SerializeField] private AudioSource JumpSoundEffect;
    float verticalmove;
    public bool isJumping;
    public bool lizing;
    public int doubleJump = 2;
    private object collision;
    public bool Ispaused = false;

    public bool changeSkin;
    public bool changeSkinSHIRST;
    void Awake()
    {
        instance = this;
        changeSkin = true;  
    }

    // Start is called before the first frame update
    private void Start()

    {
        AnimRefresh1();


        InvokeRepeating("ResetX", 0f, 3f);
        Tello = false;
       // anim.SetBool("run", true);


        int x = 0;
        //Time.timeScale = 1f;
 



        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();
      //  anim = GetComponent<Animator>();
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isJumping = true;
        lizing = true;
        if (x==0)
        {
            Sefid.SetActive(false);
            Zard.SetActive(false);
            Ghermez.SetActive(false);
        }

    }

    // Update is called once per frame
    private void Update()
    {
       // if (changeSkin)
      //  {
       //     for (int i = 0; i < shirtList.Length; i++)
       //     {
       //         shirtList[i].SetActive(false);

       //         if (i == shirtList.Length-1)
       //         {
       //             changeSkinSHIRST = true;
       //             changeSkin = false;
         //       }
       //     }
      //  }
      if (Enemy.BullWar)
        {
            BulletWarning.SetActive(true);
        }
      else
        {
            BulletWarning.SetActive(false);
        }


        if (changeSkinSHIRST)
        {
            int shirtSelected = PlayerPrefs.GetInt("Shirt");
           // shirtList[shirtSelected].SetActive(true);
            Debug.Log(shirtSelected);
            changeSkinSHIRST = false;
        }

        x12 = x;

        while (x < 0)
        {
            x = 0;
        }
        if (x == 0)
        {
            Zard.SetActive(false);
            Ghermez.SetActive(false);
        }

        if (x == 1)
        {
            Zard.SetActive(true);
            Ghermez.SetActive(false);
        }
        if (x == 2)
        {
            Zard.SetActive(false);
            Ghermez.SetActive(true);
        }
        if ( x >=3)
        {
            WalkSpeed = 0f;
            anim.SetBool("LOSE",true );
            
        }
        
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
    public void UpadateAnimationUpdate()
    {
        MovmentState SState;

        if(dirx > 0f)
        {
           
            SState = MovmentState.Running;
            Sprite.flipX = false;
        }
        else if (dirx < 0f)
        {

            SState = MovmentState.Running;
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
            SState = MovmentState.Jumping;
            Debug.Log(SState);
        }
            
        

        
       // else if(rb.velocity.y < -0.1f)
      //  {
      //      state = MovmentState.Falling;
      //  }
        else
        {
            SState = MovmentState.Running;
        }
            if (lizing==false)
            SState = MovmentState.Leez; 

           if (Tello == true)
            SState = MovmentState.Telo;

           if (ShieldAbility.ShieldAnimm==true)
            anim.SetLayerWeight(3, 1f);
           else if (ShieldAbility.ShieldAnimm==false)
            anim.SetLayerWeight(3, 0f);

           if (Boost==true)
            anim.SetLayerWeight(2, 1f);
           else if (Boost==false)
            anim.SetLayerWeight(2, 0f);

           if (MagnetCoin.MagnetAnimm == true)
            anim.SetLayerWeight(1, 1f);
           else if (MagnetCoin.MagnetAnimm==false)
            anim.SetLayerWeight(1, 0f);

           







        anim.SetInteger("SState", (int)SState);
       
     }

    
    public void endanim()
    {
     //   anim.Play("run");
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
            if (WalkSpeed != 0)
            {
                x++;

                anim.SetTrigger("TELOOO");
                Debug.Log("chale");
                SpeedReset();
                WalkSpeed = 8f;
                Invoke("SpeedReset", 1.2f);
                StartCoroutine(EnemyDistance());
            }
            


        }
    }
    IEnumerator EnemyDistance()
    {
        bool Tello = false;
        yield return new WaitForSeconds(9f);
       // x--;
    }
    void ResetX()
        { x -= decreaseAmount; }
    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "SpeedBoost")
        {
           // anim.SetTrigger("RunFast");
            Debug.Log("SpeedBoost");
            WalkSpeed = 20f;
           

        }

    }
    */
    public void SpeedReset()
    {
        Boost=false;
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
        if(lizing)
        {
           // anim.SetTrigger("Leez");
            lizing = false;
            Debug.Log("Liz");
            
            StartCoroutine(leez());
            
        }
      //  MovmentState state;
       
       
       

    }
    IEnumerator leez()
    {
        yield return new WaitForSeconds(0.5f);
        lizing = true;
    }
    public void SpeedBoost()
    {
        Boost=true;
       //anim.SetBool("BICYCLE" , true);
        Debug.Log("SpeedBoost");
        WalkSpeed = 20f;
        Invoke("SpeedReset", 6f);

    }
    public void RunShield()
    {
        anim.SetBool("RunShield", true);
       // Invoke(1f);
        anim.SetBool("RunShield", false);
    }
   

    public void AnimRefresh1()
    {
        anim.SetLayerWeight(0, 1f);
        anim.SetLayerWeight(1, 0f);
        anim.SetLayerWeight(2, 0f);
        anim.SetLayerWeight(3, 0f);

    }








}
