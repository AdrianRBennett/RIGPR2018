using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMove : Command {

	public const string identifier = "move";

	public CommandMove() {
		names = new string[] {
			identifier
		};
	}

	public override string GetIdentifier() {
		return identifier;
	}
}
