using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Handling : MonoBehaviour {

    // Holds the materials to be switched (public so they need to be manually added to the object).
    public Material blankScreen;
    public Material mainScreen;
    public Material highlightScreen;

    // Bool to determine if the screen is highlighted or not (Requires function to change).
    private bool highlightScreenOn = false;

    // Bool to determine if the main screen is on or not.
    public bool mainScreenOn = false;


	void Start () {
        // Sets the objects material to the "blank" state.
        SetMat(blankScreen);
    }
	
	// The updates the current screen depending on the bools above.
	void Update () {

        // Changes to the mainScreen mat. This is placed before the highlighted section to override it.
        if(mainScreenOn == true)
        {
            SetMat(mainScreen);     // Uses a function to reduce redundant code.

        }
        // Similar to above but changes to highlighted AND turns the bool off. This is to change the screen to blank when it's not being highlighted anymore.
        else if (highlightScreenOn == true) {
            SetMat(highlightScreen);
            highlightScreenOn = false;
        }
        // Changes to blankScreen mat if the above bools are all false.
        else
        {
            SetMat(blankScreen);
        }
	}

    // This function should get called when the mouse (soon to be controller) is hovering over the object which this is attached to.
    public void highlight()
    {
        // So long as the main screen isn't on the highlighted bool will change to true.
       if(mainScreenOn == false)
        {
            highlightScreenOn = true;
        }
    }

    // Replaced "GetComponent<Renderer>().material = ..." with this function to avoid repeating the code too much above.
    private void SetMat(Material newMat)
    {
        GetComponent<Renderer>().material = newMat;
    }

}
