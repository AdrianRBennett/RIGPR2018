using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneData : MonoBehaviour {
	/*
		Stores data specific to the current scene. Separate subclasses are used for each scene. 
	*/ 
	public Command[] commandList;	// Array of the currently available commands.
}
