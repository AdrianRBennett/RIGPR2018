using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Item {

	protected const string MoveName = CommandMove.identifier;

	public Blue() {
		names = new string[] {
			"blue"
		};
	}

	public override void TakeCommand(string commandName) {
		switch (commandName) {
		case MoveName:
			BeMoved ();
			break;
		}
	}

	// UNIQUE ITEM FUNCTIONALITY

	protected void BeMoved() {
		gameObject.transform.SetPositionAndRotation (
			new Vector3 (2.5f, -1.0f, 0.0f),
			Quaternion.identity);
	}
}
