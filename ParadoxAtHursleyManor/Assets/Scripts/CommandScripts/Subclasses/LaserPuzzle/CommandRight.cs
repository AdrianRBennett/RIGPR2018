using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRight : Command {

    public const string identifier = "right";

    public CommandRight()
    {
        names = new string[] {
            identifier
        };
    }

    public override string GetIdentifier()
    {
        return identifier;
    }
}
