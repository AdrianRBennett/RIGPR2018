using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandLeft : Command {

    public const string identifier = "left";

    public CommandLeft()
    {
        names = new string[] {
            identifier,
            "clockwise"
        };
    }

    public override string GetIdentifier()
    {
        return identifier;
    }
}
