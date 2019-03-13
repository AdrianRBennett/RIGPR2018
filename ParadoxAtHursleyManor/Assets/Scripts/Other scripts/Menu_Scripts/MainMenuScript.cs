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
    public Image blackScreen;     // The "black screen" image that fades in and out.
    public Animator anim;   // The Animator which handles both the fade in and fade out animations.


    // The slider object to access the slider functionalities (Slider Functionalities have been moved to a seperate script).
    private GameObject slider;           
    

    // Since most important variables are set to private they are initialized here.
    private void Start()
    {
        OptionScreen = GameObject.Find("Options Screen");   
        StartScreen = GameObject.Find("Start Screen");
        QuitScreen = GameObject.Find("Quit Screen");
        slider = GameObject.Find("Slider");
    }

    // Turns on the start screen unless it's already on in which case it changes to the next scene.
    public void StartM()
    {
        if (StartScreen.GetComponent<Material_Handling>().mainScreenOn == false)
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

    // Turns the options menu on.
    public void OptionM()
    {
        // Turns the options screen ad deactivates the others.
        if (OptionScreen.GetComponent<Material_Handling>().mainScreenOn == false)
        {
            CloseOthers(OptionScreen);
            OptionScreen.GetComponent<Material_Handling>().mainScreenOn = true;
            Debug.Log("Options open");
        }
        // Unless it's already on in which case it deactivates the menu and the slider.
        else
        {
            OptionScreen.GetComponent<Material_Handling>().mainScreenOn = false;
            Debug.Log("Options closed");
            slider.GetComponent<Slider_Script>().active = false;
        }
    }

    // Turns on the quit screen unless it's already on at which point it turns game off (Not while playing Unity Engine).
    public void QuitM()
    {
        // Switches the screen on computer on and turns others off when called (if it's not already on).
        if (QuitScreen.GetComponent<Material_Handling>().mainScreenOn == false)
        {
            CloseOthers(QuitScreen);
            QuitScreen.GetComponent<Material_Handling>().mainScreenOn = true;
        }
        // IF it's already on then it will instead quit the game.
        else
        {
            QuitScreen.GetComponent<Material_Handling>().mainScreenOn = false;
            Debug.Log("Quit");
            Application.Quit();     // Quits the game (Only in build mode).
        }

    }

    // Controls the activation of the "slider" (Could easily be duplicated for multiple sliders).
    public void Slider()
    {
        // Activates the slider IF it's unactivated and if the options screen is on. 
        if (slider.GetComponent<Slider_Script>().active == false
            && OptionScreen.GetComponent<Material_Handling>().mainScreenOn == true)
        {
            slider.GetComponent<Slider_Script>().active = true;
        }
        // ELSE it deactivates the slider.
        else
        {
            slider.GetComponent<Slider_Script>().active = false;
            Debug.Log(slider.GetComponent<Slider_Script>().CalculatePercentage());  // Debug displays the percentage value created by slider.
        }

    }

    // This function changes all other screens to "blank" when one screen is selected.
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

    // As the name says this controls the change from this current scene to the next one in the scene roster.
    public IEnumerator SceneChange()
    {
        // Simple count down with a debuging output. 
        for(int i = 0; i < 5; i++)
        {
            Debug.Log(5 - i);
            yield return new WaitForSecondsRealtime(1);
        }

        anim.SetBool("Exit", true);     // Starts the transition from FadeIn to FadeOut
        yield return new WaitUntil(() => blackScreen.color.a == 1);   // Waits for the black screen to become fully opaque (controlled by the a in rgba).
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // Changes to the next scene in the build index (This is set in the build settings).
    }

}
