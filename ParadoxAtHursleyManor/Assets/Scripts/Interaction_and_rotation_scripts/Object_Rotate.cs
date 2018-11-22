using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rotate : MonoBehaviour {

    // Attach this to the Mirror_Prefab asset, which is attached to the Mirror_Object and located in the Programmer art folder.
    // This script could be attached to any object indevidually however in this instance updating the prefab file will update
    // all other prefabs in the game (if this is unclear ask Oscar).
    
    public Transform target;

    private void Start()
    {
        target.eulerAngles = transform.eulerAngles;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * 1.0f);
    }

    public void RotateObjectRight()
    {
        target.Rotate(Vector3.up * 45);
    }

    public void RotateObjectLeft()
    {
        target.Rotate(Vector3.up * -45);
    }

    public void RotateObjectUp()
    {
        target.Rotate(Vector3.right * -45);
    }

    public void RotateObjectDown()
    {
        target.Rotate(Vector3.right * 45);
    }
}
