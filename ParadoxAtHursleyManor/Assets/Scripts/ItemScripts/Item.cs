using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
	/*
		An abstract class that all items in the game should inherit from.
	*/ 

	// PUBLIC MEMBERS

	public string[] names;									// An array of words that this item can be identified with.
	public ItemPosition basePos = null;					// An item's initial position.

	// PROTECTED MEMBERS

	protected ItemPosition position = null;					// An item's current position.
	protected Player playerRef;								// A reference to the player object.

	protected void Start() {
		position = GetComponentInParent<ItemPosition> ();
		playerRef = FindObjectOfType<Player> ();
		InitNames ();
	}

	// PUBLIC METHODS

	public virtual void ReturnToBasePos () {
		/*
			Returns this item to its base position.
		*/ 
		basePos.heldItem = this;
		position = basePos;
	}
	public abstract void TakeCommand (string commandName);	// An abstract function to be overridden with a switch case that handles command functionality.
	public virtual void BePlaced (ItemPosition newPos)	{	// Should be overidden by placeable objects with placement functionality. 	
		Debug.Log("No placement functionality for this Item");
	}

	// PROTECTED METHODS

	protected abstract void InitNames ();					// Initialises the name list of the Item.
}
