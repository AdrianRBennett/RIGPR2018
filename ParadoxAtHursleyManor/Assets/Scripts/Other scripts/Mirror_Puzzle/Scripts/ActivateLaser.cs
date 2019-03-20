using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActivateLaser : MonoBehaviour {

    public SteamVR_Action_Boolean LaserToggle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (LaserToggle.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            gameObject.GetComponent<Emitter_Script>().active_Laser = true;
        }
	}
}
