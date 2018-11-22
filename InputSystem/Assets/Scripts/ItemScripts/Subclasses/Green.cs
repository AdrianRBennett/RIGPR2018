using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : Item {

	void Start() {
		names = new string[] {
			"green"
		};
	}

	public override void TakeCommand(string commandName) {
		switch (commandName) {
		case "move":
			gameObject.transform.SetPositionAndRotation (new Vector3 (2.5f, 2.0f, 0.0f), Quaternion.identity);
			break;
		}
	}
}