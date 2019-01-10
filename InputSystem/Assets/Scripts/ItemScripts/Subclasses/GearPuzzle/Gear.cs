using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : HoldableItem {

	// PUBLIC MEMBERS

	Orientation Orient = new Orientation();

	// PROTECTED MEMBERS

	protected const string FlipName = CommandFlip.identifier;

	// PUBLIC METHODS

	public override void TakeCommand(string commandName) {
		base.TakeCommand (commandName);
		switch (commandName) {
		case FlipName:
			BeFlipped ();
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

	protected void BeFlipped() {
		if (Orient.yOrientation != (Orientation.OrientState)((Orientation.noOfStates - 1) * Orientation.stateOffset)) {
			Orient.yOrientation += Orientation.stateOffset;
		} else {
			Orient.yOrientation = Orientation.OrientState.state1;
		}
	}
}
