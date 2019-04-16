using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWatson : MonoBehaviour {

    public GameObject Watson;
    public GameObject WatsonPrefab;
    
	// Use this for initialization
	void Start () {
		if(Watson == null)
        {
            Watson = GameObject.Find("Watson_Obj");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(Watson);
            Watson = Instantiate(WatsonPrefab);
            Watson.name = "Watson_Obj";
        }
	}
}
