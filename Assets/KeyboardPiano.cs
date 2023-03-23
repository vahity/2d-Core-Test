using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyboardPiano : MonoBehaviour
{
    public GameObject[] pianoKey;
    public AudioSource[] Sound;

    public float timeRemaining = 0.2f;

    public int randomPiano;
    int pianoKeyRandom;

    bool PianoFinish;
    int RightKey;

    void Start()
    {
        PianoFinish = false;

        //randomPiano = Random.Range(0, 2);
        randomPiano = 0;
        RightKey = 0;
        if (randomPiano == 0)
            StartCoroutine(GetPiano_03());
        /*  if (randomPiano == 1)
              StartCoroutine(GetPiano_05());
          if (randomPiano == 2)
              StartCoroutine(GetPiano_07());
        */
    }

    private void Update()
    {
        if (PianoFinish)
        {
            for (int i = 0; i < pianoKey.Length; i++)
            {
                pianoKey[i].SetActive(false);
            }
        }
        if (RightKey == 1)
        {
            PlayerPrefs.SetInt("Health", 3);
            SceneManager.LoadScene("Level 4");
        }
    }

    IEnumerator GetPiano_03()
    {
        yield return new WaitForSeconds(timeRemaining);
        pianoKeyRandom = Random.Range(0, 11);
        pianoKey[pianoKeyRandom].SetActive(true);
        Sound[pianoKeyRandom].Play();

        yield return new WaitForSeconds(timeRemaining);
        pianoKeyRandom = Random.Range(0, 11);
        pianoKey[pianoKeyRandom].SetActive(true);
         Sound[pianoKeyRandom].Play();

        yield return new WaitForSeconds(timeRemaining);
        pianoKeyRandom = Random.Range(0, 11);
        pianoKey[pianoKeyRandom].SetActive(true);
        Sound[pianoKeyRandom].Play();

        yield return new WaitForSeconds(timeRemaining);
        PianoFinish = true;

        yield return new WaitForSeconds(5f);
        RightKey++;

    }



    /*
    IEnumerator GetPiano_05()
    {
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
       // Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
       // Sound[pianoKey.Length].Play(); 
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
       // Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
       // Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
       // Sound[pianoKey.Length].Play();
    }

    IEnumerator GetPiano_07()
    {
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
      //  Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
      //  Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
      //  Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
       // Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
      //  Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
      //  Sound[pianoKey.Length].Play();
        yield return new WaitForSeconds(timeRemaining);
        pianoKey[Random.Range(0, 11)].SetActive(true);
       // Sound[pianoKey.Length].Play();
    }
*/
}
