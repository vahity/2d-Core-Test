using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Sprite bgImage;
    public List<Button> btns =new List<Button> ();
    public Sprite[] Puzzel;
    public List<Sprite> GamePuzzels =new List<Sprite> ();
    private bool firstGuess;
    private bool scoundeGuess;

    private int countGuesses;
    private int countcorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex; 
    private string firstGuessPuzzel, scoundGuessPuzzel;
    void Awake()
    {
        Puzzel = Resources.LoadAll<Sprite>("Sprites/Candy");
    }
    void Start()
    {
        GetButtons ();
        Addlisteners ();
        AddGamePuzzels();
        gameGuesses = GamePuzzels.Count/2;
        Shuffle (GamePuzzels);
        GameStart ();
    }
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzelButton");
        for(int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
        
    }
    void AddGamePuzzels ()
    {
        int Lopper = btns.Count;
        int index = 0;  
        for(int i = 0; i < Lopper; i++)
        {
            if(index==Lopper/2)
            {
                index = 0;
            }
            GamePuzzels.Add(Puzzel[index]);
            index++;
           // btns.Add(objects[i].GetComponet<Button>());
          //  btns.[i].image.sprite = bgImage;
        }
    }

    void Addlisteners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(()=> PickAPuzzele());
        }
    }
    public void PickAPuzzele()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("CLICK" + name);
        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzel = GamePuzzels[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = GamePuzzels[firstGuessIndex];

        }
        else if(!scoundeGuess)
        {
            scoundeGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            scoundGuessPuzzel = GamePuzzels[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = GamePuzzels[secondGuessIndex];
            StartCoroutine(CheckIfPuzzelsMatch());
        }

    }
    IEnumerator CheckIfPuzzelsMatch()
    {
        yield return new WaitForSeconds(0.5f);
        if(firstGuessPuzzel== scoundGuessPuzzel)
        {
            yield return new WaitForSeconds(0.3f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            checkifthegamefinished();
        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            btns[firstGuessIndex].image.sprite= bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(0.5f);
        firstGuess = scoundeGuess = false;
    }
    void checkifthegamefinished()
    {
        countcorrectGuesses++;
        if(countcorrectGuesses==gameGuesses)
        {
            SceneManager.LoadScene(("Mini 2")) ;



        }
    }
    void Shuffle(List<Sprite> List)
    {
        for(int i = 0; i < List.Count; i++)
        {
            Sprite temp = List[i];
            int randomeIndex = Random.Range(i, List.Count);
            List[i] = List[randomeIndex];
            List[randomeIndex] = temp;
        }
    }
    void GameStart ()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzelButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns[i].image.sprite = GamePuzzels[i];
            Debug.Log("yaaah");
        }
        Invoke("GameResume", 3f);
        
    }
    void GameResume()
    {
        Debug.Log("sabr kard");
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzelButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns[i].image.sprite = bgImage;

        }
    }
}
