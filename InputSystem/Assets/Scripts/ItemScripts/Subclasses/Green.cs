using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : HoldableItem {

	protected override void InitNames() {
		names = new string[] {
			"green"
		};
	}

	// PUBLIC METHODS

	public override void TakeCommand(string commandName) {
		switch (commandName) {
		case "move":
			gameObject.transform.SetPositionAndRotation (new Vector3 (2.5f, 2.0f, 0.0f), Quaternion.identity);
			break;
		case "pickup":
			BePickedUp ();
			break;
		}
	}
}