using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Script : MonoBehaviour {

	private RaycastHit hit;

	// Much like the laser script, this code creates a raycast then activates a certain function on that object.
    // Unlike the mirror script activate the code depending on the input provided:
    // (All 45 degrees) L = Right, J = Left, I = Up, K = Down.
	void Update () {
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
        {
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
