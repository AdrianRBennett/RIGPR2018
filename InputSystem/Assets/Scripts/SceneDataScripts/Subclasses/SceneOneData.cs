using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneData : SceneData {

	//PUBLIC METHODS

	public SceneOneData()
	{
		commandList = new Command[] {
			new CommandPickUp ()
		};
	}
}
