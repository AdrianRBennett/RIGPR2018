using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HoldableItem : Item {
	/*
		An abstract class that all holdable items in the game should inherit from.
	*/ 

	// PUBLIC METHODS

	public override void ReturnToBasePos () {
		/*
			Returns this item to its base position.
		*/ 
		base.ReturnToBasePos ();
	}

	// PROTECTED METHODS

	protected void BePickedUp() {
		if (playerRef.heldItem == null) {
			playerRef.heldItem = this;
			position.heldItem = null;
			position = null;

			ChangeParentObject (playerRef.transform);
			ApplyHoldingOffset ();
		}
	}

	protected void ChangeParentObject(Transform newParent) {
		/*
			This function changes the item's parent. The offset transform is necessary as the SetParent function changes the item's trnasform
			such that there is no movement in world space. This solution maintains the local space transform whilst moving the item in world space.
		*/ 
		Vector3 tempLocalPos = transform.localPosition;
		Quaternion templocalRotation = transform.localRotation;

		transform.SetParent (newParent);
		transform.localPosition = tempLocalPos;
		transform.localRotation = templocalRotation;
	}

	protected void ApplyHoldingOffset() {
		transform.position += Vector3.forward * 2;
	}
}
