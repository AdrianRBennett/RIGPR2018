using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v
 * The Laser_Segment script is for generating further segments of 
 * a laser body when the initial laser segment collides with a
 * mirror object.
 *
 * HOW IT FUNCTIONS
^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v */

public class Laser_Segment : MonoBehaviour {

    // The Laser Segment Prefab, necessary for creating the Laser Body.
    [Tooltip("Add the 'Laser_Segment' prefab object here.")]
    public GameObject Laser_Pref;

    // The Laser Segment Object, necessary for moving the Laser Body.
    [HideInInspector]
    public GameObject Laser_Seg;

    // The raycast hit component which is important for raycast logic.
    private RaycastHit newHit;


    // This function will generate the next segment of the laser body when called. It takes in:
    // The raycast hit from the previous laser segment,
    // A directional Vector3 which is the direction the previous segment was facing,
    // And a counter to label the current segment.
    public void GenerateLaser(RaycastHit oldHit, Vector3 Incomming, int counter)
    {
        
        if(Laser_Seg == null)
        {
            Laser_Seg = Instantiate(Laser_Pref) as GameObject;
            Laser_Seg.name = "Laser_Segment_" + counter;
        }
        Vector3 direction = Vector3.Reflect(Incomming, oldHit.normal);

        if (Physics.Raycast(oldHit.point, direction, out newHit))
        {
            CreateLaser(oldHit.point + ((newHit.point - oldHit.point) * 0.5f), newHit.distance * 0.5f, newHit.point - oldHit.point);
            if (newHit.collider.gameObject.tag == "Mirror")
            {
                Laser_Seg.GetComponent<Laser_Segment>().GenerateLaser(newHit, (newHit.point - oldHit.point), (counter + 1));
            } else if(Laser_Seg.GetComponent<Laser_Segment>().Laser_Seg != null)
            {
                RemoveLasers();
            } else if (newHit.collider.gameObject.GetComponent<DiscoBall>() != null)
            {
                newHit.collider.gameObject.GetComponent<DiscoBall>().Activate();
            } else if (newHit.collider.gameObject.GetComponent<MirrorArtefact>() != null)
            {
                newHit.collider.gameObject.GetComponent<MirrorArtefact>().Activate();
            }
        } else
        {
            CreateLaser(oldHit.point + (direction.normalized * 100.0f), 100.0f, direction);
        }
    }


    private void CreateLaser(Vector3 position, float length, Vector3 direction)
    {
        Laser_Seg.transform.position = position;
        Laser_Seg.transform.localScale = new Vector3(Laser_Seg.transform.localScale.x, length, Laser_Seg.transform.localScale.z);
        Laser_Seg.transform.LookAt(newHit.point);
        Laser_Seg.transform.Rotate(Vector3.right, 90.0f);
    }

    public void RemoveLasers()
    {
        if(Laser_Seg.GetComponent<Laser_Segment>().Laser_Seg != null)
        {
            Laser_Seg.GetComponent<Laser_Segment>().RemoveLasers();
            GameObject.Destroy(Laser_Seg.GetComponent<Laser_Segment>().Laser_Seg);
        } else
        {
            GameObject.Destroy(Laser_Seg.GetComponent<Laser_Segment>().Laser_Seg);
        }
    }
}
