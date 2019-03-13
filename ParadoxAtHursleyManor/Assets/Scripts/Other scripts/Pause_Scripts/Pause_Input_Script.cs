using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Input_Script : MonoBehaviour {

    private Pause_Script PauseScript;   // Reference to the PauseScript which is attached to the same object.
    private GameObject playerCamera;    // Reference to the main camera (would be the controller).

    // The output to the raycast which is used in the RayCast() function.
    private RaycastHit hit;

    // Initializes the PauseScript and playerCameras set above with suitable references.
    private void Start()
    {
        PauseScript = GetComponent<Pause_Script>();
        playerCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame. Detecting inputs are set in functions to keep them neat.
    void Update()
    {
        ScanKeys();
        RayCast();
    }

    // Scans keyboard input and activates pause functions accordingly.
    void ScanKeys()
    {
        // Uses IF's because the Input.GetKeyDown() function isnt suitable for a switch function.
        if (Input.GetKeyDown(KeyCode.P))            // "P" Key pauses and unpauses the game.
        {
            // Detects if the game is unpaused or not.
            if (PauseScript.paused == false)
            { 
                PauseScript.Activate();
            } else
            {
                PauseScript.Resume();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))       // "Esc" Key activates the quit scritp.
        {
            PauseScript.Quit();
        }

        if (Input.GetKeyDown(KeyCode.O))            // "O" Key activates the options script.
        {
            PauseScript.Option();
        }

        if (Input.GetKeyDown(KeyCode.S))            // "S" Key activates the slider script.
        {
            PauseScript.SliderAct();
        }
    }

    void RayCast()
    {
        // First it casts a ray from the camera (soon to be controller) and detects if it hits something with a collider.
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            // When it does it detects if that object has the script to handle materials or not. 
            if (hit.collider.GetComponent<Material_Handling>() != null)
            {
                // IF it does then it it detects whether or not the primary/left mouse button (classed in the function as 0) is clicked or not.
                if (Input.GetMouseButtonDown(0))
                {
                    // IF it is then it will run a menu script depending on the name of the object (It's important that this matches the name of the screen).
                    switch (hit.collider.gameObject.name)
                    {
                        case "Resume Button":
                            PauseScript.Resume();
                            break;
                        case "Option Button":
                            PauseScript.Option();
                            break;
                        case "OptionExit Button":
                            PauseScript.Option();
                            break;
                        case "Quit Button":
                            PauseScript.Quit();
                            break;
                        default:
                            Debug.Log("Error, object name not recognized.");
                            break;
                    }

                }
                // IF the mouse isn't being clicked then it will run the highlight function on the object being detected.
                else
                {
                    hit.collider.GetComponent<Material_Handling>().highlight();
                }
            }
        }
    }
}
