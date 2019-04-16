using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandOpen : Command {

    public const string identifier = "open";

    public CommandOpen()
    {
        names = new string[] {
            identifier,
            "break",
            "crack"
        };
    }

    public override string GetIdentifier()
    {
        return identifier;
    }

}
