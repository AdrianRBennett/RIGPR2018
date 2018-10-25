using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_On_Trigger : MonoBehaviour {

    public Material newMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMaterial()
    {
        GetComponent<Renderer>().material = newMat;
    }
}
