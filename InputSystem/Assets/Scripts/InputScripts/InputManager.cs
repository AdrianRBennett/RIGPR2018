using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public string[] latestInputWordList;
	public UnityEngine.UI.Text testText;

	//PRIVATE VARIABLES
	 
	private char[] splittingCharacters = new char[] {	// The input string is split at each instance of these characters.
		' '
	};

	void Start () {
		latestInputWordList = new string[] { "default" };
	}

	void Update () {
		testText.text = latestInputWordList [0];

	}

	public void SplitInputToWordList(string input) {

		latestInputWordList = input.Split (splittingCharacters);

		if (latestInputWordList.Length >= 2) {
			int test = 0;
		}
	}
}
