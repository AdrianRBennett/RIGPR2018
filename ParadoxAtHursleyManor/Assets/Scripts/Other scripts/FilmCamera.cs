using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmCamera : MonoBehaviour {

    public float speed = 10.0f;
    public float maxSpeed = 20.0f;

    public float rotateSpeed = 2.0f;     // Speed value for the mouse movement

    private float yaw;       // Current Y rotation of the camera
    private float pitch;     // Current X rotation of the camera

    public GameObject filmCamera;

	// Use this for initialization
	void Start () {
        yaw = filmCamera.transform.eulerAngles.y;
        pitch = filmCamera.transform.eulerAngles.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.lockState = CursorLockMode.Locked;
            yaw += rotateSpeed * Input.GetAxis("Mouse X");   // Adds input to the yaw based on input
            pitch -= rotateSpeed * Input.GetAxis("Mouse Y"); // Adds input to the pitch based on input
            filmCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}
}
