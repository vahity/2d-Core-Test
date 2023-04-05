using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Drawing;

public class Player_Life : MonoBehaviour
{
    public TMP_Text Cointext, GTime, wcointext, wGtime;
    public float Coinval;
    public ItemCollector ic;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource khord;
    public float GameTime;


    public GameObject Health_01, Health_02, Health_03, Health_04, Health_05;

    public int saveHealth = 5;


    public int Health;

    public GameObject menuLose;

    private void Awake()
    {
        //load health save player
        // saveHealth = PlayerPrefs.GetInt("Health");
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Health = 5;

        //if save health == 5
        if (saveHealth == 5)
        {
            //health image true
            Health_01.SetActive(true);
            Health_02.SetActive(true);
            Health_03.SetActive(true);
            Health_04.SetActive(true);
            Health_05.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snow")
        {
            Debug.Log("khord");
            Khord();


            Health -= 1;

            if (Health == 4)
            {
                Health_01.SetActive(false);
                //save kon health ro ba health= health - 1;
                PlayerPrefs.SetInt("Health", saveHealth);
                saveHealth--;
            }
            if (Health == 3)
            {
                Health_02.SetActive(false);
                //save kon health ro ba health= health - 1;
                PlayerPrefs.SetInt("Health", saveHealth);
                saveHealth--;
            }
            if (Health == 2)
            {
                Health_03.SetActive(false);
                //save kon health ro ba health= health - 1;
                PlayerPrefs.SetInt("Health", saveHealth);
                saveHealth--;
            }
            if (Health == 1)
            {
                Health_04.SetActive(false);
                //save kon health ro ba health= health - 1;
                PlayerPrefs.SetInt("Health", saveHealth);
                saveHealth--;
            }

            if (Health == 0)
            {
                Health_05.SetActive(false);
                //save kon health ro ba health= health - 1;
                PlayerPrefs.SetInt("Health", saveHealth);

                saveHealth--;
                //health == 0


                Die();
            }
        }
        if (other.tag == "bullet")
        {
            Debug.Log("moooordBaAshaee");
            Die();
        }
    }

    private void Die()
    {
        GameTime = Time.time;

        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        menuLose.SetActive(true);
        GTime.text = GameTime.ToString();
        Cointext.text = ic.score.ToString();
        ic.Savecoin();
        ic.Getcoin();
    }
    public void win()
    {
        wcointext.text = ic.score.ToString();
        wGtime.text = GameTime.ToString();

    }
    private void Khord()
    {
        khord.Play();

    }
   

}
