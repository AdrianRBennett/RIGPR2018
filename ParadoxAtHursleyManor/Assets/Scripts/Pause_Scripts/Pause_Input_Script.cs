using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Input_Script : MonoBehaviour {
    private Pause_Script pause;
    private GameObject playerCamera;
    private RaycastHit hit;

    private void Start()
    {
        pause = GetComponent<Pause_Script>();
        playerCamera = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {
        ScanKeys();
        RayCast();
    }

    // Scans keys and activates scripts from Menu accordingly.
    void ScanKeys()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pause.paused == false)
            {
                pause.Activate();
            } else
            {
                pause.Resume();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.Quit();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            pause.Option();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pause.SliderAct();
        }
    }

    void RayCast()
    {
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if (hit.collider.GetComponent<Material_Handling>() != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    switch (hit.collider.gameObject.name)
                    {
                        case "Resume Button":
                            pause.Resume();
                            break;
                        case "Option Button":
                            pause.Option();
                            break;
                        case "OptionExit Button":
                            pause.Option();
                            break;
                        case "Quit Button":
                            pause.Quit();
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
