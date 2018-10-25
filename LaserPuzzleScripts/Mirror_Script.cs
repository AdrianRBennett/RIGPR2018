using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Script : MonoBehaviour {

    public GameObject Laser_Cylinder;

    public void ReflectLaser(RaycastHit hit, Vector3 incoming) {
        RaycastHit newHit;
        if(Physics.Raycast(hit.point, Vector3.Reflect(incoming,hit.normal), out newHit)){
            if (newHit.collider.gameObject.GetComponent<Mirror_Script>() != null)
            {
                newHit.collider.gameObject.GetComponent<Mirror_Script>().ReflectLaser(newHit, Vector3.Reflect(incoming, hit.normal));
            }
        }

        Laser_Cylinder.transform.position = hit.point;
        Laser_Cylinder.transform.LookAt(newHit.point);
        Laser_Cylinder.transform.localScale = new Vector3(1.0f, 1.0f, (newHit.distance * 10.0f));
        Debug.DrawLine(hit.point, newHit.point, Color.blue, 0.1f);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
