using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPosition : MonoBehaviour {
	/*
		A position from which items can be placed and taken.
	*/ 

	// PUBLIC MEMBERS

	[System.NonSerialized]	// (Hidden in inspector)
	public bool canBePlacedIn = false;
	public Item heldItem = null;

	// PUBLIC METHODS

	public virtual string[] GetNames() { 	// To be overwritten by placeable item positions.
		return new string[] {
			""
		};
	}		

	public virtual bool CheckItemFitsPosition() {
		return false;
	}

	// PROTECTED METHODS

	protected void Start() {
		if (GetComponentInChildren<Item> () != null) {
			heldItem = GetComponentInChildren<Item> ();
			heldItem.basePos = this;
		}
	}
}
