using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UserManager : MonoBehaviour
{
   // public static UserManager instance;
    public int Shirt = 0;
    private void Awake()
    {
      //  if (instance == null)
       //     instance = this;
      //  DontDestroyOnLoad(instance);
    }
    void Start()
    {
        PlayerPrefs.SetInt("Shirt", Shirt);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
