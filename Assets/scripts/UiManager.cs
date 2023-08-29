using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

	int score;
	public Text textScore; 
	bool GameOver;
	public Button []btn;

	void Start () {
		GameOver = false;
		score = 0;
		InvokeRepeating ("UpdateScore",1f,0.7f);

        Time.timeScale = 1;
       // Invoke("hi", 2f);
        


    }
	
	// Update is called once per frame
	void Update () {
		if(textScore!=null)
		textScore.text = "Score:"+score;
	}
	void UpdateScore(){
		if (!GameOver) {
			
			score++;
		}
	}
	public void gameOver(){	
		GameOver = true;
		foreach(Button but in btn){
			but.gameObject.SetActive (true);
		}
	}
	public void Play(){
		//	Application.LoadLevel("levele1");
		//Application.LoadLevel(1);
		SceneManager.LoadScene("levele11");/*, LoadSceneMode.Single);*/ 
	}

	public void pause(){
		if (Time.timeScale == 1)
			Time.timeScale = 0;
		else if (Time.timeScale ==0)
			Time.timeScale = 1;
	}
	public void MENU(){
		//	Application.LoadLevel("levele1");
		//Application.LoadLevel(1);
		SceneManager.LoadScene("menu11");/*, LoadSceneMode.Single);*/ 
	}
	public void EXIT(){
		Application.Quit();

	}
    public void hi()
	{
		Debug.Log("hi");
        Time.timeScale = 1;

    }
}
