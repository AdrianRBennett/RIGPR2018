using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : HoldableItem {

	// PUBLIC MEMBERS

	public Orientation requiredYOrient;
	public Orientation requiredZOrient;
	public string gearID = "";

	// PROTECTED MEMBERS

	protected const string FlipName = CommandFlip.identifier;
	protected const string RotateName = CommandRotate.identifier;

	protected Orientation yOrient = new Orientation();
	protected Orientation zOrient = new Orientation();
	protected const int orientStateOffset = 90;
	protected const int noOfOrientStates = 4;

	// PUBLIC ENUMS

	public enum Orientation {
		state1 = 0,
		state2 = 90,
		state3 = 180,
		state4 = 270
	};

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

	public override void BePlaced(ItemPosition newPos) {
		if (yOrient == requiredYOrient &&
			zOrient == requiredZOrient &&
			gearID == newPos.GetNames()[0]	) {
			base.BePlaced (newPos);
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
		ChangeOrientation (ref yOrient);

		transform.localEulerAngles = new Vector3(
			transform.localEulerAngles.x,
			(float)yOrient,
			transform.localEulerAngles.z);
	}

	protected void BeRotated() {
		ChangeOrientation (ref zOrient);

		transform.localEulerAngles = new Vector3(
			transform.localEulerAngles.x,
			transform.localEulerAngles.y,
			(float)zOrient);
	}

	protected void ChangeOrientation(ref Orientation orient) {
		if (orient != (Orientation)((noOfOrientStates - 1) * orientStateOffset)) {
			orient += orientStateOffset;
		} else {
			orient = Orientation.state1;
		}
	}
}
