using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandScan : Command {

    public const string identifier = "scan";

    public CommandScan()
    {
        names = new string[] {
            identifier,
            "scanned",
            "scand"
        };
    }

    public override string GetIdentifier()
    {
        return identifier;
    }
}
