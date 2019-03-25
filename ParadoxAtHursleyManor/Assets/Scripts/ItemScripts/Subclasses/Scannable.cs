using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : Item {

    //private GameObject scanBoard;

    
    protected override void InitNames()
    {
        if (names.Length < 1)
        {
            names = new string[] {
            identifier
            };
        }

        if (identifier == "")
        {
            identifier = names[0];
        }
    }

    

    
}
