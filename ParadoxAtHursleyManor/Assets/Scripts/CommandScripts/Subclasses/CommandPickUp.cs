using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPickUp : Command {

	public const string identifier = "pickup";

	public CommandPickUp() {
		names = new string[] {
			identifier,
			"pick",
			"grab",
			"take"
		};
	}

	public override string GetIdentifier() {
		return identifier;
	}
}
