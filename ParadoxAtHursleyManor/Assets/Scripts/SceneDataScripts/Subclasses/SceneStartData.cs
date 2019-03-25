using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartData : SceneData {

    void Start()
    {
        commandList = new Command[] {
            new CommandScan()
        };
    }
}
