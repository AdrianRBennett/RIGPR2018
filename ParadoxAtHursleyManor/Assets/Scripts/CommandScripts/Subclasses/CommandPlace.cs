﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPlace : Command {

	public const string identifier = "place";

	public CommandPlace() {
		names = new string[] {
			identifier,
            "police",
            "please"
		};
	}

	public override string GetIdentifier() {
		return identifier;
	}
}
