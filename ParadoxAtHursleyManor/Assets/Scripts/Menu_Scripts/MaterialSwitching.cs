using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitching : MonoBehaviour {

    public Material Mat1;
    public Material Mat2;
   

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material = Mat1;
	}

    public void ScreenOn(bool on)
    {
        if (on)
        {
            GetComponent<Renderer>().material = Mat2;
        } else
        {
            GetComponent<Renderer>().material = Mat1;
        }
    }
}
