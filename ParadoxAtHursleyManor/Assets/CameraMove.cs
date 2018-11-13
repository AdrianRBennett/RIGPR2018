using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


    public float speed = 10.0f;     // Speed of xyz movement
    public float maxSpeed = 20.0f;  // Maximum speed
    private float oldSpeed;         // Temporary speed value

    public float speedH = 2.0f;     // Speed value for the mouse movement
    public float speedV = 2.0f;     // Speed value for the mouse movement

    private float yaw = 0.0f;       // Current Y rotation of the camera
    private float pitch = 0.0f;     // Current X rotation of the camera

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.None; // Unlocks the cursor at start of game;
        oldSpeed = speed;                       // Sets up the temporary value;
    }
	
	// Update is called once per frame
	void Update () {

        // Boosts movement speed to max while left shift is held
        if (Input.GetKey(KeyCode.LeftShift))   
        {
            if(speed != maxSpeed)
            {
                oldSpeed = speed;
                speed = maxSpeed;
            }
        }
        else // Resets speed back to normal when left shift is released
        {
            speed = oldSpeed;
        }
        // Keyboard (Forward Back, Straffe, Up Down)
        float translation = Input.GetAxis("Vertical") * speed;  // Detects when vertical inputs are pressed. Positive (W, UpArrow), Negative (S, DownArrow) 
        float straffe = Input.GetAxis("Horizontal") * speed;    // Detects when horizontal inputs are pressed. Positive (A), Negative (D) 
        float rise = Input.GetAxis("Jump") * speed;             // Detects when Jump inputs are pressed. Positive (Space, R), Negative (F) 
        translation *= Time.deltaTime;                          // Multiplies by delta time to keep it smooth
        straffe *= Time.deltaTime;                              // ...
        rise *= Time.deltaTime;                                 // ...

        // Translates the camera
        transform.Translate(straffe, rise, translation);        


        // Rotates the camera based on cursor movement while Fire2 (Right mouse, left alt) is held
        if (0 != Input.GetAxis("Fire2"))
        {
            // Locks the cursor to the center of the game screen
            Cursor.lockState = CursorLockMode.Locked;

            yaw += speedH * Input.GetAxis("Mouse X");   // Adds input to the yaw based on input
            pitch -= speedV * Input.GetAxis("Mouse Y"); // Adds input to the pitch based on input

            // Rotates camera based on mouse movement
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        else 
        {
            // Unlocks the cursor while Fire2 is not pressed
            Cursor.lockState = CursorLockMode.None;
        }

        
	}
}
