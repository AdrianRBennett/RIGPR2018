using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimativeInputManager : MonoBehaviour {
    private MainMenuScript MenuScript;
    private GameObject playerCamera;

    private void Start()
    {
        MenuScript = GetComponent<MainMenuScript>();
        playerCamera = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update () {
        ScanKeys();
        RayCast();
	}

    // Scans keys and activates scripts from Menu accordingly.
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

    void RayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if (hit.collider.GetComponent<Material_Handling>() != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    switch (hit.collider.gameObject.name)
                    {
                        case "Start Screen":
                            MenuScript.StartM();
                            break;
                        case "Options Screen":
                            MenuScript.OptionM();
                            break;
                        case "Quit Screen":
                            MenuScript.QuitM();
                            break;
                        default:
                            Debug.Log("Error, object name not recognized.");
                            break;
                    }

                }
                else
                {
                    hit.collider.GetComponent<Material_Handling>().highlight();
                }
            }
        }
    }
}
