using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class VSon_Movement : MonoBehaviour {

    private GameObject playerCamera;

    private Transform fixedCamera;

    private Vector3 lerpPos;

    private RaycastHit hit;

    public float y_angle;
    public float y_position;
    public float x_offput;

    [Range(0.01f,0.9f)]
    public float lerp;

	// Use this for initialization
	void Start () {
		playerCamera = GameObject.Find("Camera");
	}
	
	// Update is called once per frame
	void Update () {
        fixedCamera = playerCamera.transform;
        fixedCamera.position.Set(fixedCamera.position.x, y_position, fixedCamera.position.z);
        
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.right, 3.0f))
        {
            fixedCamera.Rotate(-fixedCamera.eulerAngles.x, -y_angle, 0);
        }
        else
        {
            fixedCamera.Rotate(-fixedCamera.eulerAngles.x, y_angle, 0);
        }

        lerpPos = fixedCamera.position + (fixedCamera.forward * x_offput);


        transform.position = Vector3.Lerp(transform.position, lerpPos, lerp);
        transform.LookAt(playerCamera.transform);

        

    }
}
