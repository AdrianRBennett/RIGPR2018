using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause_Script : MonoBehaviour {

    private GameObject menu;

    private GameObject resume;
    private GameObject option;
    private GameObject quit;

    private GameObject measure;

    private GameObject cameraObj;

    public bool quiting;
    public bool options;

	// Use this for initialization
	void Start () {
        menu = GameObject.Find("Menu");
        resume = GameObject.Find("Resume Button");
        option = GameObject.Find("Option Button");
        quit = GameObject.Find("Quit Button");
        measure = GameObject.Find("Measuring");
        cameraObj = GameObject.Find("Camera");
        menu.SetActive(false);
        measure.SetActive(false);
    }


    public void SetupMenu(Vector3 newPosition) {
        transform.position = newPosition;
        transform.position = new Vector3(transform.position.x, cameraObj.transform.position.y, transform.position.z);
        menu.SetActive(true);
        measure.transform.position = new Vector3(newPosition.x, 3, newPosition.z);
        SetupText(0);
    }

    public void DisableMenu() {
        menu.SetActive(false);

    }

    public int Stage()
    {
        if(quiting == false && options == false)
        {
            return 1;
        }
        else if(quiting == true && options == false)
        {
            return 2;
        }
        else if(quiting == false && options == true)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }

    public void SetupText(int stage)
    {
        switch (stage)
        {
            case 0:
                resume.GetComponentInChildren<TextMeshPro>().text = "Resume";
                option.GetComponentInChildren<TextMeshPro>().text = "Options";
                quit.GetComponentInChildren<TextMeshPro>().text = "Quit";
                break;
            case 1:
                resume.GetComponentInChildren<TextMeshPro>().text = "Adjust your height with the measuring stick";
                option.GetComponentInChildren<TextMeshPro>().text = "Use left and right on the D-Pad";
                quit.GetComponentInChildren<TextMeshPro>().text = "Back";
                break;
            case 2:
                resume.GetComponentInChildren<TextMeshPro>().text = "YES";
                option.GetComponentInChildren<TextMeshPro>().text = "Are you sure?";
                quit.GetComponentInChildren<TextMeshPro>().text = "NO";
                break;
            default:
                break;
        }
    }

    public int ResumeButton()
    {
        if(Stage() == 1)
        {
            return 0;
        } else if(Stage() == 2)
        {
            return 1;
        } else
        {
            return 3;
        }
    }

    public void OptionsButton()
    {
        if(Stage() == 1)
        {
            options = true;
            SetupText(1);
        }
    }

    public void QuitButton()
    {
        if(Stage() == 1)
        {
            quiting = true;
            SetupText(2);
        } else if(Stage() == 2)
        {
            quiting = false;
            SetupText(0);
        } else if(Stage() == 3)
        {
            options = false;
            SetupText(0);
        }
    }

	// Update is called once per frame
	void Update () {
		if(menu.activeSelf == true)
        {
            //transform.position = new Vector3(transform.position.x, cameraObj.transform.position.y, transform.position.z);

            menu.transform.LookAt(cameraObj.transform);



            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x, cameraObj.transform.position.y, transform.position.z), 0.1f);
        }

	}
}
