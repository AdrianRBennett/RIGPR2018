using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation {

	// PUBLIC MEMBERS

	public const int stateOffset = 90;
	public const int noOfStates = 4;

	public enum OrientState {
		state1 = 0,
		state2 = 90,
		state3 = 180,
		state4 = 270
	};

	public OrientState yOrientation;
	public OrientState zOrientation;

	// PUBLIC METHODS

	public Orientation() {
		yOrientation = OrientState.state1;
		zOrientation = OrientState.state1;
	}
}
