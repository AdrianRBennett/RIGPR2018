using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearArtefact : MonoBehaviour {

    public GameObject artefact;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            artefact.SetActive(true);
            artefact.GetComponent<Rigidbody>().AddForce(((transform.up * 3) + transform.forward) * 150.0f);
        }
	}
}
