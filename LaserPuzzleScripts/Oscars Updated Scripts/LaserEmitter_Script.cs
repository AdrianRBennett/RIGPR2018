using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter_Script : MonoBehaviour {


    public GameObject Laser_Origin;

    public GameObject Laser_Cylinder;

    void CreateLaser() {
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
        DrawLaser(hit, Laser_Origin.transform.position);
        Debug.DrawLine(Laser_Origin.transform.position, hit.point, Color.blue, 0.1f);
    }

	void DrawLaser(Raycast hit, Vector3 origin){
		Laser_Cylinder.transform.position = origin;
        	Laser_Cylinder.transform.LookAt(hit.point);
        	Laser_Cylinder.transform.localScale = new Vector3(1.0f, 1.0f, (hit.distance * 5.0f));
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CreateLaser();
	}
}
