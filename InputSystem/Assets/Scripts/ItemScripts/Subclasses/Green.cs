using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : HoldableItem {

	// PROTECTED MEMBERS

	protected const string MoveName = CommandMove.identifier;

	// PUBLIC METHODS

	public override void TakeCommand(string commandName) {
		switch (commandName) {
		case MoveName:
			BeMoved ();
			break;
		case PickUpName:
			BePickedUp ();
			break;
		case DropName:
			BeDropped ();
			break;
		}
	}

	// PROTECTED METHODS

	protected override void InitNames() {
		names = new string[] {
			"green"
		};
	}

	// UNIQUE ITEM FUNCTIONALITY

	protected void BeMoved() {
		gameObject.transform.SetPositionAndRotation (new Vector3 (2.5f, 2.0f, 0.0f), Quaternion.identity);
	}
}