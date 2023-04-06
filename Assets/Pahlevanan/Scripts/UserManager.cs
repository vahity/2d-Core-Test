using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager instance;
    public int Shirt = 0;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(instance);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
