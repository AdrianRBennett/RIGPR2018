using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rotate : MonoBehaviour {

    private Quaternion target;

    private void Start()
    {
        target = transform.rotation;
    }

    private void Update()
    {
        Quaternion current = transform.rotation;
        transform.rotation = Quaternion.Slerp(current, target, Time.deltaTime);
    }

    public void RotateObjectRight()
    {
        target.eulerAngles.Set(target.eulerAngles.x,(target.eulerAngles.y + 45), target.eulerAngles.z);
        transform.Rotate(Vector3.up * 45);
    }

    public void RotateObjectLeft()
    {
        transform.Rotate(Vector3.up * -45);
    }

    public void RotateObjectUp()
    {
        transform.Rotate(Vector3.right * 45);
    }

    public void RotateObjectDown()
    {
        transform.Rotate(Vector3.right * -45);
    }
}
