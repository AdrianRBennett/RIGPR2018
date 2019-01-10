using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandFlip : Command {

	public const string identifier = "flip";

	public CommandFlip() {
		names = new string[] {
			identifier
		};
	}
	
	public override string GetIdentifier() {
		return identifier;
	}
}
