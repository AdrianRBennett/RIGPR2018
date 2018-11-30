using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimativeInputManager : MonoBehaviour {
    MainMenuScript MenuScript;


    private void Start()
    {
        MenuScript = GetComponent<MainMenuScript>();
    }
    // Update is called once per frame
    void Update () {
        ScanKeys();
	}

    void ScanKeys()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MenuScript.StartM();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuScript.QuitM();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            MenuScript.OptionM();
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MenuScript.Slider();
        }
    }
}
