using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v
 * The Emitter_Script is the starting base for the updated laser
 * scripts.
 * 
 * HOW IT FUNCTIONS
^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v */


public class Emitter_Script : MonoBehaviour {

    // The Laser Segment Prefab, necessary for creating the Laser Body.
    [Tooltip("Add the 'Laser_Segment' prefab object here.")]
    public GameObject Laser_Pref;    

    // The Laser Segment Object, necessary for moving the Laser Body.
    private GameObject Init_Laser_Seg;  

    // The raycast hit component which is important for raycast logic.
    private RaycastHit hit;

    // A toggle switch to turn the laser on and off.
    [Tooltip("Toggle the laser ON or OFF")]
    public bool active_Laser = true;


    // Update is called once per frame.
    void Update () {

        // First checking if laser is active.
        if (active_Laser == true)
        {
            // Checking if the Laser_Segment has NOT been initialized.
            if(Init_Laser_Seg == null)
            {
                // If it hasn't/it was destroyed previously then re-initialize it.

                Init_Laser_Seg = Instantiate(Laser_Pref) as GameObject; // This initializes it which generates a clone of the prefab into the game.
                Init_Laser_Seg.name = "Laser_Segment_1";                // This names the object clone.
            }

            // This casts a ray from the emitter object in the Y direction of the object. If it hits a collider then it will return true and output the results to the hit object.
            if (Physics.Raycast(transform.position, transform.up, out hit))
            {
                // These lines of code set the position, scale and rotation of the laser segment.
                Init_Laser_Seg.transform.position = transform.position + ((hit.point - transform.position) * 0.5f); // Position: This calculates the midpoint between the lasers origin and the point the ray hits an object.
                Init_Laser_Seg.transform.localScale = new Vector3(Init_Laser_Seg.transform.localScale.x, hit.distance * 0.5f, Init_Laser_Seg.transform.localScale.z); // Scale: This calculates the distance the ray traveled from the emitter and scales Y component of the segment by half that value. It keeps the X and Z components the same.
                Init_Laser_Seg.transform.rotation = transform.rotation; // Rotation: Since the laser segment is similar to the current laser emitter it copys the emitters rotation.


                // This checks to see if the ray has hit a mirror object and it does this by checking if the object has the "Mirror" Tag attached. If it has it will generate a new laser segment.
                if (hit.collider.gameObject.tag == "Mirror")
                {
                    // Here we call the "GenrerateLaser" function (See Laser_Script); it passes the raycast hit, calculates a directional vector from the emitter to the hit object, and passes a counter to signify it's the second segment in the laser body. 
                    Init_Laser_Seg.GetComponent<Laser_Segment>().GenerateLaser(hit,     
                                                (hit.point - transform.position),   
                                                2);
                    
                }
                // IF the object is not a mirror then it check to see if there is a second laser segment in the laser body. 
                else if (Init_Laser_Seg.GetComponent<Laser_Segment>().Laser_Seg != null)
                {
                    // This function check if any segments have been built in the chain and removes them if the are.
                    Init_Laser_Seg.GetComponent<Laser_Segment>().RemoveLasers();
                    
                    // This destorys the the second laser segment which would only exist if the first segment has hit a mirror.
                    GameObject.Destroy(Init_Laser_Seg.GetComponent<Laser_Segment>().Laser_Seg);
                }
            }
            // In the case the raycast has not hit a collider we still need to draw a laser.
            else
            {
                // These lines of code set the position, scale and rotation of the laser segment in the case that the raycast did not collide.
                Init_Laser_Seg.transform.position = transform.position + (transform.up * 100.0f);   // Position: This finds a point that is 100 units from the direction the ray was cast.
                Init_Laser_Seg.transform.localScale = new Vector3(Init_Laser_Seg.transform.localScale.x, 100.0f, Init_Laser_Seg.transform.localScale.z);    // Scale: This scales the Y value up by 100 units, keeping the X and Z units the same. 
                Init_Laser_Seg.transform.rotation = transform.rotation; // Rotation: Since the laser segment is similar to the current laser emitter it copys the emitters rotation.
            }
        }

        // If the laser is not active then it will stop creating a laser body.
        else
        {
            // This checks to see if the initial laser segment exists, if it does then it will need to destroy it.
            if (Init_Laser_Seg != null)
            {
                if (Init_Laser_Seg.GetComponent<Laser_Segment>().Laser_Seg != null)
                {
                    // This function check if any segments have been built in the chain and removes them if the are.
                    Init_Laser_Seg.GetComponent<Laser_Segment>().RemoveLasers();

                    // This destorys the the second laser segment which would only exist if the first segment has hit a mirror.
                    GameObject.Destroy(Init_Laser_Seg.GetComponent<Laser_Segment>().Laser_Seg);
                }

                // This destroys the initial laser segment, the first part of the laser body.
                GameObject.Destroy(Init_Laser_Seg);
            }
        }
	}
}
