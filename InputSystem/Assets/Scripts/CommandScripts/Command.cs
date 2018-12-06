using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {
	/*
		An abstract class that represents a spoken command. All commands should inherit from this class.
	*/ 
	// PUBLIC MEMBERS
	public string[] names;	// An array of words that this command can be identified with.

	public abstract string GetIdentifier ();
}
