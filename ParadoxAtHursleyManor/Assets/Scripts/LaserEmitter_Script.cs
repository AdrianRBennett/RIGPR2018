using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter_Script : MonoBehaviour {

    public GameObject Laser_Origin;

    public float Max_RayCast;

    public GameObject Laser_Cylinder;

    void CreateLaser() {
		/*
			Produces a laser in accordance to raycast data. It checks for collisions of the laser with other objects and
			calls relevant functions to allow them to interact.
		*/ 
        RaycastHit hit;
        if (Physics.Raycast(Laser_Origin.transform.position, Laser_Origin.transform.forward, out hit)) {
            if (hit.collider.gameObject.GetComponent<Mirror_Script>() != null)
            {
                hit.collider.gameObject.GetComponent<Mirror_Script>().ReflectLaser(hit, Laser_Origin.transform.forward);
            } else if (hit.collider.gameObject.GetComponent<Activate_On_Trigger>() != null)
            {
                hit.collider.gameObject.GetComponent<Activate_On_Trigger>().ChangeMaterial();
            }
        }
		UpdateLaserCylinder (hit);
    }

	private void UpdateLaserCylinder(RaycastHit hit) {
		/*
			Updates the Laser Cylinder's variables to ensure it renders according to the raycast data.
		*/ 
		Laser_Cylinder.transform.position = Laser_Origin.transform.position;
		Laser_Cylinder.transform.LookAt(hit.point);
		Laser_Cylinder.transform.localScale = new Vector3(1.0f, 1.0f, (hit.distance * 5.0f));
	}
	
	// Update is called once per frame
	void Update () {
        CreateLaser();
	}
}
