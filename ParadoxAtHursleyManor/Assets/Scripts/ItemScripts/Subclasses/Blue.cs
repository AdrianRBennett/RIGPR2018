using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Item {

	// PROTECTED MEMBERS

	protected const string MoveName = CommandMove.identifier;

	// PUBLIC METHODS

	public override void TakeCommand(string commandName) {
		switch (commandName) {
		case MoveName:
			BeMoved ();
			break;
		}
	}

	// PROTECTED METHODS

	protected override void InitNames() {
		names = new string[] {
			"blue"
		};
	}

	// UNIQUE ITEM FUNCTIONALITY

	protected void BeMoved() {
		gameObject.transform.SetPositionAndRotation (
			new Vector3 (2.5f, -1.0f, 0.0f),
			Quaternion.identity);
	}
}
