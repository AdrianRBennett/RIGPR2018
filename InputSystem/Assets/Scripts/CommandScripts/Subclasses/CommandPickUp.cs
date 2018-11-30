using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPickUp : Command {

	public CommandPickUp() {
		names = new string[] {
			"pickup",
			"pick",
			"grab",
			"take"
		};
	}
}
