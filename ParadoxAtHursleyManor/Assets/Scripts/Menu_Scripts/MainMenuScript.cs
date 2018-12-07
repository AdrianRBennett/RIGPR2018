using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour{  

    // The screen objects to change their colors during operations.
    private GameObject OptionScreen;
    private GameObject StartScreen;
    private GameObject QuitScreen;


    // Image and Animator for the fade in and fade out effects.
    public Image black;     // The "black screen" image that fades in and out.
    public Animator anim;   // The Animator which handles both the fade in and fade out animations.


    // Slider variables (Slider Functionalities have been moved to a seperate script).
    private GameObject slider;           // The transform component of the slider object we want to move.
    

    // Since most important variables are set to private they are initialized here.
    private void Start()
    {
        OptionScreen = GameObject.Find("Options Screen");
        StartScreen = GameObject.Find("Start Screen");
        QuitScreen = GameObject.Find("Quit Screen");
        slider = GameObject.Find("Slider");
    }


    public void StartM()
    {
        if(StartScreen.GetComponent<Material_Handling>().mainScreenOn == false)
        {
            CloseOthers(StartScreen);
            StartScreen.GetComponent<Material_Handling>().mainScreenOn = true;
            Debug.Log("Preparing to launch.");
        } else
        {
            StartScreen.GetComponent<Material_Handling>().mainScreenOn = false;
            Debug.Log("Starting Game");
            StartCoroutine("SceneChange");
        }

    }


    public void OptionM()
    {
        if (OptionScreen.GetComponent<Material_Handling>().mainScreenOn == false)
        {
            CloseOthers(OptionScreen);
            OptionScreen.GetComponent<Material_Handling>().mainScreenOn = true;
            Debug.Log("Options open");
        } else
        {
            OptionScreen.GetComponent<Material_Handling>().mainScreenOn = false;
            Debug.Log("Options closed");
        }
    }


    public void QuitM()
    {
        if (QuitScreen.GetComponent<Material_Handling>().mainScreenOn == false)
        {
            CloseOthers(QuitScreen);
            QuitScreen.GetComponent<Material_Handling>().mainScreenOn = true;
        }
        else
        {
            QuitScreen.GetComponent<Material_Handling>().mainScreenOn = false;
            Debug.Log("Quit");
            Application.Quit();
        }

    }


    public void Slider()
    {
        if (slider.GetComponent<Slider_Script>().active == false
            && OptionScreen.GetComponent<Material_Handling>().mainScreenOn == true)
        {
            slider.GetComponent<Slider_Script>().active = true;
        }
        else
        {
            slider.GetComponent<Slider_Script>().active = false;
            Debug.Log(slider.GetComponent<Slider_Script>().CalculatePercentage());
        }

    }


    private void CloseOthers(GameObject exception)
    {
        if(exception != OptionScreen)
        {
            OptionScreen.GetComponent<Material_Handling>().mainScreenOn = false;
        }
        if(exception != StartScreen)
        {
            StartScreen.GetComponent<Material_Handling>().mainScreenOn = false;
        }
        if(exception != QuitScreen)
        {
            QuitScreen.GetComponent<Material_Handling>().mainScreenOn = false;
        }
    }


    public IEnumerator SceneChange()
    {
        for(int i = 0; i < 5; i++)
        {
            yield return new WaitForSecondsRealtime(1);
            Debug.Log(5 - i);
        }
        anim.SetBool("Exit", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
