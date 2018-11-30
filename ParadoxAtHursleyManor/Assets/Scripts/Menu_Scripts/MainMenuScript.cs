using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour{

    private int menuIndex = 0; // This controls which menu is currently active (0 for none, 1 for start, 2 for options, 3 for quit).

    private GameObject player;

    public GameObject OptionScreen;
    public GameObject StartScreen;
    public GameObject QuitScreen;

    private float lockFloat;
    private bool sliderAct = false;
    public float minS;
    public float maxS;
    private Transform slider;

    private void Start()
    {
        player = GameObject.Find("Main Camera");
        slider = GameObject.Find("Slider").transform;
    }

    private void Update()
    {
        if (sliderAct)
        {
            slider.localPosition = new Vector3(
                (-player.transform.rotation.y) + slider.localPosition.x,
                slider.localPosition.y,
                slider.localPosition.z);
            if (slider.localPosition.x <= minS)
            {
                slider.localPosition = new Vector3(
                    minS,
                    slider.localPosition.y,
                    slider.localPosition.z);
            } else if (slider.localPosition.x >= maxS)
            {
                slider.localPosition = new Vector3(
                    maxS,
                    slider.localPosition.y,
                    slider.localPosition.z);
            }
        }
    }


    private void UpdateScreens()
    {
        switch (menuIndex)
        {
            case 0:
                StartScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                OptionScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                QuitScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                break;
            case 1:
                StartScreen.GetComponent<MaterialSwitching>().ScreenOn(true);
                OptionScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                QuitScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                break;
            case 2:
                StartScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                OptionScreen.GetComponent<MaterialSwitching>().ScreenOn(true);
                QuitScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                break;
            case 3:
                StartScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                OptionScreen.GetComponent<MaterialSwitching>().ScreenOn(false);
                QuitScreen.GetComponent<MaterialSwitching>().ScreenOn(true);
                break;
            default:
                break;
        }
    }

    public void StartM()
    {
        if(menuIndex != 1)
        {
            Debug.Log("Readying Game...");
            menuIndex = 1;
            
            UpdateScreens();
        } else
        {
            Debug.Log("Start");
            menuIndex = 0;
            UpdateScreens();
            player.GetComponent<CameraMove>().lockMovement = false;
            GetComponent<PrimativeInputManager>().enabled = false;
            GetComponent<MainMenuScript>().enabled = false;
        }
        
    }

    public void OptionM()
    {
        if (menuIndex != 2)
        {
            menuIndex = 2;

            UpdateScreens();
        } else
        {
            menuIndex = 0;
        }

    }

    public void QuitM()
    {
        if (menuIndex != 3)
        {
            menuIndex = 3;
            
            UpdateScreens();
        }
        else
        {
            menuIndex = 0;
            UpdateScreens();
            Debug.Log("Quit");
            Application.Quit();
        }

    }

    public void Slider()
    {
        if (!sliderAct && menuIndex == 2)
        {
            sliderAct = true;
        } else if (sliderAct)
        {
            sliderAct = false;
        }
    }
}
