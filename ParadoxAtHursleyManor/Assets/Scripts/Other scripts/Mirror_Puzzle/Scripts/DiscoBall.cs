using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBall : MonoBehaviour {

    public bool active = false;

    public Material newMat;
    public Material oldMat;
	
    public void Activate()
    {
        active = true;
        GetComponent<Renderer>().material = newMat;
    }

	// Update is called once per frame
	void Update () {
		if(active == true)
        {
            transform.Rotate(0.0f, 1.0f, 0.0f);
            active = false;
        }
        else
        {
            GetComponent<Renderer>().material = oldMat;
        }
	}
}
