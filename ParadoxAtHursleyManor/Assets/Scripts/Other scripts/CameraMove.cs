using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public bool lockMovement = true;


    public float speed = 10.0f;     // Speed of xyz movement
    public float maxSpeed = 20.0f;  // Maximum speed
    private float oldSpeed;         // Temporary speed value

    public float rotateSpeed = 2.0f;     // Speed value for the mouse movement

    private float yaw = 0.0f;       // Current Y rotation of the camera
    private float pitch = 0.0f;     // Current X rotation of the camera

    private float yLock;

    // Use this for initialization
    void Start () {
        //Cursor.lockState = CursorLockMode.None; // Unlocks the cursor at start of game.
        oldSpeed = speed;                       // Sets up the temporary value.
        yLock = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (!lockMovement) {
            MoveCode();     // The code to move the camera when arrow keys are pressed.
        }

        LookCode();         // The code to rotate the camera when the mouse is moved.

        // This code keeps the camera locked in the y position it was spawned in.
        transform.position = new Vector3(transform.position.x, yLock, transform.position.z);
        
	}

    private void MoveCode()
    {
        // Boosts movement speed to max while left shift is held
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (speed != maxSpeed)
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

        //float rise = Input.GetAxis("Jump") * speed;             // Detects when Jump inputs are pressed. Positive (Space, R), Negative (F) 

        translation *= Time.deltaTime;                          // Multiplies by delta time to keep it smooth
        straffe *= Time.deltaTime;                              // ...

        //rise *= Time.deltaTime;                                 // ...

        // Translates the camera
        transform.Translate(straffe, 0.0f, translation);
    }

    private void LookCode()
    {
        // Rotates the camera based on cursor movement while Fire2 (Right mouse, left alt) is held
        if (0 == Input.GetAxis("Fire2"))
        {
            // Locks the cursor to the center of the game screen
            Cursor.lockState = CursorLockMode.Locked;

            yaw += rotateSpeed * Input.GetAxis("Mouse X");   // Adds input to the yaw based on input
            pitch -= rotateSpeed * Input.GetAxis("Mouse Y"); // Adds input to the pitch based on input

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
