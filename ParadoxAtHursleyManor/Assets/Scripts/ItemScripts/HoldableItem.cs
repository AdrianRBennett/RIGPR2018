using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HoldableItem : Item {
	/*
		An abstract class that all holdable items in the game should inherit from.
	*/ 

	// PROTECTED MEMBERS

	//protected const string PickUpName = CommandPickUp.identifier;
	//protected const string DropName = CommandDrop.identifier;

    protected CommandPickUp cPickup = new CommandPickUp();
    protected CommandDrop cDrop = new CommandDrop();

    // PUBLIC METHODS

    public override void TakeCommand(string commandName) {
        base.TakeCommand(commandName);

        foreach(string name in cPickup.names)
        {
            if(name == commandName)
            {
                BePickedUp();
                break;
            }
        }

        foreach (string name in cDrop.names)
        {
            if (name == commandName)
            {
                BeDropped(); 
                break;
            }
        }

        //switch (commandName) {
		//case PickUpName:
		//	BePickedUp ();
		//	break;
		//case DropName:
		//	BeDropped ();
		//	break;
		//}
	}

	// PROTECTED METHODS

	protected void BePickedUp() {						// "Pick Up" Command Functionality
		if (playerRef.heldItem == null) {
			playerRef.heldItem = this;
			//position.heldItem = null;
			position = null;

			ChangeParentObject (playerRef.transform);
			ApplyHoldingOffset ();
		}
	}

	protected void BeDropped() {						// "Drop" Command Functionality
		if (basePos.heldItem == null) {
			ReturnToBasePos ();
			playerRef.heldItem = null;
			ChangeParentObject (basePos.transform);
		} else {
			Debug.Log ("This item cannot return to its base position as its base position is holding another item.");
		}
	}

	public override void BePlaced (ItemPosition newPos)	// "Place" Command Functionality
	{
		playerRef.heldItem = null;
		position = newPos;
		newPos.heldItem = this;
		RemoveHoldingOffset ();
		ChangeParentObject (newPos.transform);
	}

	protected void ChangeParentObject(Transform newParent) {
		/*
			This function changes the item's parent transform. The temporary transform is necessary as the SetParent function changes the item's transform
			such that there is no movement in world space. This solution maintains the local space transform whilst moving the item in world space.
		*/ 
		Vector3 tempLocalPos = transform.localPosition;
		Quaternion templocalRotation = transform.localRotation;

		transform.SetParent (newParent);
		transform.localPosition = tempLocalPos;
		transform.localRotation = templocalRotation;
	}

	protected void ApplyHoldingOffset() {
		/*
			Applies an offset to the item's position so that it is stays at a certain distance from its parent along the its forward axis.
		*/ 
		transform.position += Vector3.forward * 2;
	}

	protected void RemoveHoldingOffset() {
		/*
			Removes the item's forward vector positional offset from its parent.
		*/ 
		transform.localPosition = Vector3.zero;
	}
}
