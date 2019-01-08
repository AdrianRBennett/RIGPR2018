using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	/*
		A class representing the player.
	*/ 

	// PUBLIC MEMBERS

	public PlayerPosition position = null;		// A reference to the player's current position.
	public HoldableItem heldItem = null;				// A reference to the player's held object.

	void Start() {
		/*
			Initialisation function. 
		*/ 
		if (GetComponentInParent<PlayerPosition> () != null) {
			position = GetComponentInParent<PlayerPosition> ();
		} else {
			Debug.Log ("The player is not stationed in a player position");
		}

		if (GetComponentsInChildren<HoldableItem> () != null) {
			heldItem = GetComponentInChildren<HoldableItem> ();
		}
	}

	// PRIVATE METHODS

	private void Move(PlayerPosition newPos) {
		/*
			Moves the player to a new player position.
		*/ 
		position = newPos;
	}

	private void PlaceItem(ItemPosition newPos) {
		/*
			Places a held item in a new item position.
		*/ 
		newPos.heldItem = heldItem;
		heldItem = null;
	}

	private void DropItem() {
		/*
			Drops held item, returning it to its base position.
		*/ 
		heldItem.ReturnToBasePos ();
		heldItem = null;
	}
}
