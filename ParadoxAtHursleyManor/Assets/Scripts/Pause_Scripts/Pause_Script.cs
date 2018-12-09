using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour {

    // References to parent objects.
    private GameObject Menu;        // This is holds the Main and Options Menus and is used to position the pause menu as well as hide them.
    private GameObject Main;        // This holds the Main Menu buttons (Resume, Options and Quit).
    private GameObject Options;     // This holds the Option Menu features (Options exit button and sliders).

    // Reference to the player camera. Used for positioning the main menu infront of the player.
    private GameObject playerCamera;    

    // Reference to the slider object to toggle the slider.
    public GameObject Slider;

    // Bool to show when the game is paused or not.
    public bool paused = false;

    // Initializes the private objects above and sets the Menus to be deactive (not visible).
    private void Start()
    {
        playerCamera = GameObject.Find("Main Camera");

        Menu = GameObject.Find("Menu");
        Main = GameObject.Find("Main");
        Options = GameObject.Find("Options");

        Menu.SetActive(false);
        Options.SetActive(false);
    }

    // This code moves the Pause menu infront of the player character and activates the main menu script.
    public void Activate() {
        // Creates a new vector which is set 5.0f units infront of the camera (Needs recalculation due to issues with using forward vector).
        Vector3 newPos = playerCamera.transform.position + (playerCamera.transform.forward * 5.0f);

        // The new vector goes through a final stage where the y value is changed to match the height of the player character.
        newPos = new Vector3(newPos.x, playerCamera.transform.position.y, newPos.z);
        
        // Now the potition of the Menu is changed to the new vector and the menu is rotated towards the player camera.
        transform.position = newPos;
        transform.LookAt(playerCamera.transform);

        paused = true;              
        Menu.SetActive(true);       // Sets the collective Menus to active to make them visible.
        Main.SetActive(true);       // Sets the Main Menu to active to make it visible.
        Options.SetActive(false);   // Sets the Options menu to inactive to make it invisible.

        GameObject.Find("Main Camera").GetComponent<CameraMove>().lockMovement = true;  // Locks the players movement.
        GameObject.Find("Main Camera").GetComponent<Interact_Script>().active = false;  // Disables the players ability to interact with mirrors.
    }

    // This function deactivates the pause menu.
    public void Deactivate()
    {
        paused = false;
        Menu.SetActive(false);      // Hides all menus from player.
        GameObject.Find("Main Camera").GetComponent<CameraMove>().lockMovement = false;     // Unlocks the players movement.
        GameObject.Find("Main Camera").GetComponent<Interact_Script>().active = true;       // Activates the players ability to interact with objects.
    }

    // Function that quits game when activated (only in fully built mode).
    public void Quit()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }

    // Deactivates the pause menu through seperate function (this is incase anything else needs to be added to the resume function later).
    public void Resume() {
        Debug.Log("Resuming");
        Deactivate();
    }

    // This changes between the Main and Options menu depending on which is currently open.
    public void Option()
    {
        // IF the main menu is open then it deactivates the main menu and activates the options menu.
        if(Options.activeSelf == false)
        {
            Main.SetActive(false);
            Options.SetActive(true);
        }
        // IF the main menu is closed then it activates the main menu, deactivates the options menu and deactivates the slider.
        else
        {
            Main.SetActive(true);
            Options.SetActive(false);
            SliderAct();
        }
    }

    // This toggles the slider.
    public void SliderAct()
    {
        // IF the options menu is active then it toggles the slider to be on.
        if(Options.activeSelf == true)
        {
            Slider.GetComponent<Slider_Script>().active = true;
        }
        // IF the options menu isn't on OR the slider is already active then it deactivates the slider.
        else if (Options.activeSelf == false || Slider.GetComponent<Slider_Script>().active == true)
        {
            Slider.GetComponent<Slider_Script>().active = false;
            Debug.Log(Slider.GetComponent<Slider_Script>().CalculatePercentage());
        }
    }
}
