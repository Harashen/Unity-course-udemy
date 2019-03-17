using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizards : MonoBehaviour {

    const int max = 1001;
    const int min = 1;
    int guess;

    // Use this for initialization
    void Start () {
        StartGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            NextGuess();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess;
            NextGuess();
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            print("I won!");
            StartGame();
        }
	}

    void StartGame() {
        guess = 500;

        Debug.Log("========================");
        Debug.Log("Welcome to Number Wizard");
        Debug.Log("Pick a number in your head, but don't tell me!");

        Debug.Log("The highest number you can pick is " + max);
        Debug.Log("The lowest number you can pick is "  + min);

        Debug.Log("Is the number higher or lower than " + guess + "?");
        Debug.Log("Up = higher, down = lower, return = equal");
    }

    void NextGuess() {
        guess = (max + min) / 2;

        Debug.Log("Higher or lower than " + guess + "?");
        Debug.Log("Up = higher, down = lower, return = equal");
    }
}
