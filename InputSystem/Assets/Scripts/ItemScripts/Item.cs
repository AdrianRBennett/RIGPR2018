using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
	/*
		An abstract class that all items in the game should inherit from.
	*/ 

	// PUBLIC MEMBERS

	public bool canBeHeld = false;							// A flag to track if the item can be held.
	public bool isHeld = false;								// A flag to track the item's held state.
	public string[] names;									// An array of words that this item can be identified with.

	// PROTECTED MEMBERS

	protected ItemPosition basePos = null;					// An item's base position.

	// PUBLIC METHODS

	public void ReturnToBasePos () {
		/*
			Returns this item to its base position.
		*/ 
		basePos.heldItem = this;
		isHeld = false;
	}
	public abstract void TakeCommand (string commandName);	// An abstract function to be overridden with a switch case that handles command functionality.
}
