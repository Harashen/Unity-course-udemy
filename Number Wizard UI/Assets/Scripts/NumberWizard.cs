using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;

    public int maxGuessesAllowed = 10;
    public Text guessText;

    // Use this for initialization
    void Start () {
        StartGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("I won!");
            StartGame();
        }
	}

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    void StartGame() {
        max = 1000;
        min = 1;

        NextGuess();
    }

    void NextGuess() {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();


        if (--maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
