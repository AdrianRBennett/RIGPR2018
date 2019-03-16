using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRotate : Command {

	public const string identifier = "rotate";

	public CommandRotate() {
		names = new string[] {
			identifier,
            "turn"
		};
	}

	public override string GetIdentifier() {
		return identifier;
	}
}
