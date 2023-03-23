using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loadingscreen : MonoBehaviour
{

    
        public GameObject  Loadingscren ;
        public Image LoadingBarFill;


        public void loadScene(int sceneId)
        {
            StartCoroutine(LoadSceneAsynce(sceneId));

        }

        IEnumerator LoadSceneAsynce(int sceneId)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

            Loadingscren.SetActive(true);

            while(!operation.isDone)
            {
                float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

                LoadingBarFill.fillAmount = progressValue;




                yield return null;
            }
        }
    }

