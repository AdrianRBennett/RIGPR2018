using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Telepad_Script : MonoBehaviour {
    private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
	}

    private void Update()
    {
        if(meshRenderer.enabled == true)
        {
            meshRenderer.enabled = false;
        }
    }

    public void ViewObject()
    {
        meshRenderer.enabled = true;
    }
}
