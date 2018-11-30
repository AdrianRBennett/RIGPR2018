using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_On_Trigger : MonoBehaviour {
	/*
		A script to be applied to a game object that reacts to a laser coming into contact with it.
	*/ 
    public Material newMat;
    public void ChangeMaterial()
    {
        GetComponent<Renderer>().material = newMat;
    }
}
