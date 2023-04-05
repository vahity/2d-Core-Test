using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_done : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Home());
        IEnumerator Home()
        {
            yield return new WaitForSeconds(4.5f);
            Debug.Log("sabr kard");
            SceneManager.LoadScene("NewMenu");

        }
    }
    public void Home()
    {
        SceneManager.LoadScene("NewMenu");
    }
    
    
    
}
