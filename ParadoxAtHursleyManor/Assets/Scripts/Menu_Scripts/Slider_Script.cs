using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Script : MonoBehaviour {

    public bool active = false;
    public float minX;
    public float maxX;
    private GameObject playerCamera;
    


	// Use this for initialization
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

    public float CalculatePercentage()
    {
        return ((-transform.localPosition.x + maxX) / (Mathf.Abs(minX) + Mathf.Abs(maxX))) * 100.0f;
    }
}
