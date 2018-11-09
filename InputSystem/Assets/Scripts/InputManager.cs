using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public string[] latestInputWordList;
	public UnityEngine.UI.Text testText;


	void Start () {
		latestInputWordList = new string[] { "default" };
	}

	void Update () {
		testText.text = latestInputWordList [0];
	}

	public void SplitInputToWordList(string input) {

		latestInputWordList = new string[] {
			input
		};
	}
}
