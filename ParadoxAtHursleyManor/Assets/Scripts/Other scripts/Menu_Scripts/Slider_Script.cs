using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Script : MonoBehaviour {

    // Determines if the slider will move or not.
    public bool active = false;

    // The max and min values the slider can reach.
    public float minX;
    public float maxX;

    // Reference to the camera (would be controller).
    private GameObject playerCamera;
    


	// Initializes the reference to the camera.
	void Start () {
        playerCamera = GameObject.Find("Main Camera");
    }
	
    // Update is called once per frame
	void Update () {
        if (active)      // Detects if slider has been activated.
        {
            // This is where the slider moves, though it's only one part thats important.
            transform.localPosition = new Vector3(
                (-playerCamera.transform.rotation.y) + transform.localPosition.x,    // This line takes the rotation of the players head and adds it to the local position of the 
                transform.localPosition.y,
                transform.localPosition.z);

            // These next if statements check if the slider has gone to far off either side then corrects it.
            if (transform.localPosition.x <= minX)
            {
                transform.localPosition = new Vector3(
                    minX,
                    transform.localPosition.y,
                    transform.localPosition.z);
            }
            else if (transform.localPosition.x >= maxX)
            {
                transform.localPosition = new Vector3(
                    maxX,
                    transform.localPosition.y,
                    transform.localPosition.z);
            }
        }
    }

    // This function creates a percentage value based on where the function is between the min and max values. This is to be used when adjusting things like sound or brightness to a certain percentage.
    public float CalculatePercentage()
    {
        // First it moves the current local position to a point where it's a number above 0 by adding the max value to it.
        // Then it's simple percentage calculation (dividing it by what would be 100% then multiplying it by 100 to get a percentage).
        return ((-transform.localPosition.x + maxX) / (Mathf.Abs(minX) + Mathf.Abs(maxX))) * 100.0f;
    }
}
