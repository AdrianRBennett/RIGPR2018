using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Test : MonoBehaviour {

    // Defining how long the laser can be (Also how many laser components, aka laserComponents, we need).
    [Range(10,20)]                  
    public int laserLength = 10;    

    // The Gameobject of the origin point. Has to be manually added to the script.
    public GameObject originPoint;

    // The prefab of the laser component. Has to be manually added to the script.
    public GameObject laserComponent;

    // The gameobject array to be filled with the laserComponents.
    private GameObject[] laserArray;


	// Use this for initialization
	void Start () {
        laserArray = new GameObject[laserLength];       // Here the code initiates the laserArray to be the desired length. Note this cannot be changed during gameplay.
        for(int i = 0; i < laserLength; i++)            // This for loop instantiates multiple versions of the LaserComponent and stores them in the array. Also puts them somewhere outside the world to hide them.
        {
            laserArray[i] = (GameObject)Instantiate(laserComponent,new Vector3(0.0f, -10.0f,0.0f),Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        // Everytime the game updates it creates a new "counter" to be used later. It runs the BuildLaser function which returns the end counter value plus 1.
        int i = BuildLaser(originPoint.transform.position, originPoint.transform.forward, 0) + 1;   // When BuildLaser is first called it takes the origin and the direction that origin is facing.
        if (i < laserLength) {
            while (i < laserLength)
            {
                laserArray[i].transform.position = new Vector3(0.0f, -10.0f, 0.0f);
                laserArray[i].transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
                i++;
            }
        }
        

    }
    int BuildLaser(Vector3 origin, Vector3 direction, int counter)
    {    
        // Creates a new output for the raycast.
        RaycastHit hit;
    
        if (Physics.Raycast(origin, direction, out hit, 1000.0f))    // Here the raycast is created and it detects when it hits something.
        {
            // If the ray hits something then this code executes:

            Debug.DrawLine(origin, hit.point, Color.blue, 0.1f);        // Drawing a debugging line to see the path of the laser without rendering.

            laserArray[counter].transform.position = origin;                                            // These lines are for drawing the laser. First it moves the current LaserComponent to where the raycast starts.
            laserArray[counter].transform.LookAt(new Vector3(hit.point.x,hit.point.y,hit.point.z));     // Next it rotates the object to look where the ray point has hit (LookAt() function is a little tricky but found a work around).
            laserArray[counter].transform.localScale = new Vector3(1.0f, 1.0f, (hit.distance * 5.0f));  // Finally the LaserComponent is stretched by the distance the ray has traveled * 5. Don't ask why it's timesed by 5 cause I dont really know.

            // Now this is where the laser is able to bounce off a mirror.
            if ((hit.transform.tag == "Mirror") && (counter < laserLength)) // First it checks if the object the ray hit had the "Mirror" tag AND if the counter has not reached the limit yet.
            { 
                // If the above statements are both true then this is where the new laser is rendered.

                Vector3 newDirection = Vector3.Reflect(direction, hit.normal); // First it sets up a new direction by using Vector3.Reflect(). Look it up or ask me, too much to explain here.
                return BuildLaser(hit.point, newDirection, (counter + 1));     // Now it recalls this function with the point the ray hit the mirror, the new direction and increases the counter by one, and it will return the highest value of counter.
            } else if (hit.transform.tag == "Trigger")
            {
                hit.collider.gameObject.GetComponent<Activate_On_Trigger>().ChangeMaterial();
            }

            return counter;
        }
        else
        {
            Debug.DrawLine(origin, VectorMath.VectorAdd(origin, direction), Color.blue, 0.1f);
            laserArray[counter].transform.position = origin;
            laserArray[counter].transform.LookAt(new Vector3(direction.x, direction.y, direction.z));
            laserArray[counter].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            return counter;
        }
    }
}
