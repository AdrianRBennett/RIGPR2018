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
            "scand",
            "scam"
        };
    }

    public override string GetIdentifier()
    {
        return identifier;
    }
}
