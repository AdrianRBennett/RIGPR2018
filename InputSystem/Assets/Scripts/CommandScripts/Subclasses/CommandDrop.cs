using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDrop : Command {

	public const string identifier = "drop";

	public CommandDrop() {
		names = new string[] {
			"drop"	
		};
	}

	public override string GetIdentifier() {
		return identifier;
	}
}
