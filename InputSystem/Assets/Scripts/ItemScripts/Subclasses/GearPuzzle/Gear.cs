using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : HoldableItem {

	// PUBLIC MEMBERS

	Orientation Orient = new Orientation();

	// PROTECTED MEMBERS

	protected const string FlipName = CommandFlip.identifier;
	protected const string RotateName = CommandRotate.identifier;

	// PUBLIC METHODS

	public override void TakeCommand(string commandName) {
		base.TakeCommand (commandName);
		switch (commandName) {
		case FlipName:
			BeFlipped ();
			break;
		case RotateName:
			BeRotated ();
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
		ChangeOrientation (ref Orient.yOrientation);

		transform.localEulerAngles = new Vector3(
			transform.localEulerAngles.x,
			(float)Orient.yOrientation,
			transform.localEulerAngles.z);
	}

	protected void BeRotated() {
		ChangeOrientation (ref Orient.zOrientation);

		transform.localEulerAngles = new Vector3(
			transform.localEulerAngles.x,
			transform.localEulerAngles.y,
			(float)Orient.zOrientation);
	}

	protected void ChangeOrientation(ref Orientation.OrientState orient) {
		if (orient != (Orientation.OrientState)((Orientation.noOfStates - 1) * Orientation.stateOffset)) {
			orient += Orientation.stateOffset;
		} else {
			orient = Orientation.OrientState.state1;
		}
	}
}
