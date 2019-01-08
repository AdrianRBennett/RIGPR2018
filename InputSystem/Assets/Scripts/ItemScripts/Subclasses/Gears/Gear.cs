using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : HoldableItem {

	// PUBLIC METHODS

	public override void TakeCommand(string commandName) {
		switch (commandName) {
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
			"gear",
			"cog"
		};
	}
}
