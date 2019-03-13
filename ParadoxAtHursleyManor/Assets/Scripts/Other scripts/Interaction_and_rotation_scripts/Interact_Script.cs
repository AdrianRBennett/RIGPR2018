using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Script : MonoBehaviour {

	private RaycastHit hit;

    public bool active = true;
    // Attach this to the main camera.

	// Much like the laser script, this code creates a raycast then activates a certain function on that object.
    // Unlike the mirror script activate the code depending on the input provided:
    // (All set rotation value) L = Right, J = Left, I = Up, K = Down.
	void Update () {
        if (active)
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
            {
		    	if (hit.collider.tag == "Mirror") {
               		if (Input.GetKeyDown(KeyCode.L))
               		{
               		    hit.collider.gameObject.GetComponent<Object_Rotate>().RotateObjectRight();
               		}
               		if (Input.GetKeyDown(KeyCode.J))
               		{
               		    hit.collider.gameObject.GetComponent<Object_Rotate>().RotateObjectLeft();
               		}
               		if (Input.GetKeyDown(KeyCode.I))
               		{
               		    hit.collider.gameObject.GetComponent<Object_Rotate>().RotateObjectUp();
               		}
               		if (Input.GetKeyDown(KeyCode.K))
               		{
               		    hit.collider.gameObject.GetComponent<Object_Rotate>().RotateObjectDown();
               		}
		    	}
            }
        }
	}
}
