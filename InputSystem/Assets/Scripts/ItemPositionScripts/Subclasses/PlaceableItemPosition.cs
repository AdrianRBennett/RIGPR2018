using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableItemPosition : ItemPosition {

	// PUBLIC MEMBERS

	public string[] names;									// An array of words that this item position can be identified with.

	// PUBLIC METHODS

	public override string[] GetNames() {
		return names;
	}

	// PRIVATE METHODS

	private new void Start() {
		base.Start ();
		canBePlacedIn = true;
	}
}
