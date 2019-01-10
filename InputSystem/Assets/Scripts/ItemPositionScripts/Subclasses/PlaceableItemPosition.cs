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
		
	public override bool CheckItemFitsPosition() {
		return true;
	}

	// PRIVATE METHODS

	protected new void Start() {
		base.Start ();
		canBePlacedIn = true;
	}
}
