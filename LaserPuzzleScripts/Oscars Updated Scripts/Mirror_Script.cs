using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Script : MonoBehaviour {

    public GameObject Laser_Cylinder;

    private bool render_Laser = false;

    public void ReflectLaser(RaycastHit hit, Vector3 incoming) {
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

        DrawLaser(newHit, hit.point);
        Debug.DrawLine(hit.point, newHit.point, Color.blue, 0.1f);
        render_Laser = true;
    }
	void DrawLaser(RaycastHit hit, Vector3 origin){
		Laser_Cylinder.transform.position = origin;
        	Laser_Cylinder.transform.LookAt(hit.point);
        	Laser_Cylinder.transform.localScale = new Vector3(1.0f, 1.0f, (hit.distance * 5.0f));
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
