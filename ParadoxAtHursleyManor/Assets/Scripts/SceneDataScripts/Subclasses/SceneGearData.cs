﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGearData : SceneData {

    void Start()
    {
        commandList = new Command[] {
            new CommandPickUp (),
            new CommandMove (),
            new CommandPlace (),
            new CommandFlip (),
            new CommandRotate (),
            new CommandLeft(),
            new CommandRight()
        };
    }
}
