using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Script : MonoBehaviour {

    public GameObject Laser_Cylinder;

    private bool render_Laser = false;

    public void ReflectLaser(RaycastHit hit, Vector3 incoming) {
		/*
			Reflects an incoming laser accordeing to its raycast data. It checks for collisions of the new laser with other objects and
			calls relevant functions to allow them to interact.
		*/ 
        RaycastHit newHit;
        if(Physics.Raycast(hit.point, Vector3.Reflect(incoming,hit.normal), out newHit)){
            if (newHit.collider.gameObject.GetComponent<Mirror_Script>() != null)
            {
                newHit.collider.gameObject.GetComponent<Mirror_Script>().ReflectLaser(newHit, Vector3.Reflect(incoming, hit.normal));
            } else if (newHit.collider.gameObject.GetComponent<Activate_On_Trigger>() != null)
            {
                newHit.collider.gameObject.GetComponent<Activate_On_Trigger>().ChangeMaterial();
            }
        }
		UpdateLaserCylinder (hit, newHit);
    }

	private void UpdateLaserCylinder(RaycastHit oldHit, RaycastHit newHit) {
		/*
			Updates the Laser Cylinder's variables to ensure it renders according to the mirror's new raycast data.
			It takes the data of the raycast causing the relection and the new raycast data as parameters.
		*/ 
		Laser_Cylinder.transform.position = oldHit.point;
		Laser_Cylinder.transform.LookAt(newHit.point);
		Laser_Cylinder.transform.localScale = new Vector3(1.0f, 1.0f, (newHit.distance * 5.0f));
		render_Laser = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(render_Laser == false && !(Laser_Cylinder.transform.position.y <= -20.0f))
        {
            Laser_Cylinder.transform.position = new Vector3(0.0f, -20.0f, 0.0f);
            Laser_Cylinder.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            render_Laser = false;
        }
        
	}
}
