using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Item {

	protected override void InitNames() {
		names = new string[] {
			"blue"
		};
	}

	// PUBLIC METHODS

	public override void TakeCommand(string commandName) {
		switch (commandName) {
		case "move":
			gameObject.transform.SetPositionAndRotation (new Vector3 (2.5f, -1.0f, 0.0f), Quaternion.identity);
			break;
		}
	}
}
