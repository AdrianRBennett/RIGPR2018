using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour {
    private GameObject Menu;
    private GameObject Main;
    private GameObject Options;

    private GameObject playerCamera;

    public GameObject Slider;

    public bool paused = false;

    private void Start()
    {
        playerCamera = GameObject.Find("Main Camera");

        Menu = GameObject.Find("Menu");
        Main = GameObject.Find("Main");
        Options = GameObject.Find("Options");

        Menu.SetActive(false);
        Options.SetActive(false);


    }

    public void Activate() {
        Vector3 newPos = playerCamera.transform.position + (playerCamera.transform.forward * 5.0f);
        newPos = new Vector3(newPos.x, playerCamera.transform.position.y, newPos.z);
        transform.position = newPos;
        transform.LookAt(playerCamera.transform);

        paused = true;
        Menu.SetActive(true);
        Main.SetActive(true);
        Options.SetActive(false);

        GameObject.Find("Main Camera").GetComponent<CameraMove>().lockMovement = true;
        GameObject.Find("Main Camera").GetComponent<Interact_Script>().active = false;

    }

    public void Deactivate()
    {
        paused = false;
        Menu.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<CameraMove>().lockMovement = false;
        GameObject.Find("Main Camera").GetComponent<Interact_Script>().active = true;
    }

    public void Quit()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }

    public void Resume() {
        Debug.Log("Resuming");
        Deactivate();
    }

    public void Option()
    {
        if(Options.activeSelf == false)
        {
            Main.SetActive(false);
            Options.SetActive(true);
        } else
        {
            Main.SetActive(true);
            Options.SetActive(false);
            SliderAct();
        }
    }

    public void SliderAct()
    {
        if(Options.activeSelf == true)
        {
            Slider.GetComponent<Slider_Script>().active = true;
        } else if (Options.activeSelf == false || Slider.GetComponent<Slider_Script>().active == true)
        {
            Slider.GetComponent<Slider_Script>().active = false;
        }
    }
}
