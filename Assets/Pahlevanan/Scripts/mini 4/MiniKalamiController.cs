using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniKalamiController : MonoBehaviour
{
    public Text questionText;
    public Image questionImage;
    public Button[] optionButtons;
    public Text scoreText;
    public Font myFont;

    public int currentQuestionIndex;
    private int score;

    private Question[] questions = new Question[]
    {
        new Question("Questions/Question1Image", new string[]{"??", "??", "??", "??"}, "??"),
        new Question("Images/Question2", new string[]{"X", "Y", "Z", "W"}, "W"),
        new Question("Images/Question3", new string[]{"Yes", "No", "Maybe", "I don't know"}, "Yes")
    };

    private void Start()
    {

        myFont = Resources.Load<Font>("MyFont");
        GetComponent<Text>().font = myFont;


        // Show the first question
        ShowQuestion();

    }

    private void ShowQuestion()
    {
        // Set the question image
        questionImage.sprite = Resources.Load<Sprite>(questions[currentQuestionIndex].imageName);

        // Set the question text
        questionText.text = "What is the correct option for this image?";

        // Set the option texts
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponentInChildren<Text>().text = questions[currentQuestionIndex].options[i];
        }
    }

    public void CheckAnswer(int buttonIndex)
    {
        if (optionButtons[buttonIndex].GetComponentInChildren<Text>().text == questions[currentQuestionIndex].correctOption)
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            Debug.Log("Correct!");
        }
        else
        {
            score--;
            scoreText.text = "Score: " + score.ToString();
            Debug.Log("Incorrect!");
        }

        // Move to the next question
        currentQuestionIndex++;
        if (currentQuestionIndex >= questions.Length)
        {
            currentQuestionIndex = 0;
        }
        ShowQuestion();
    }
}

public class Question
{
    public string imageName;
    public string[] options;
    public string correctOption;

    public Question(string imageName, string[] options, string correctOption)
    {
        this.imageName = imageName;
        this.options = options;
        this.correctOption = correctOption;
    }

}
