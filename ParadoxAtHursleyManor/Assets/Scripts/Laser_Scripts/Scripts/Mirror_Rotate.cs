using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Rotate : MonoBehaviour
{
    private bool isRotating = false;
   
    

    public void RotateLeft()
    {
        if(isRotating == false)
        {
            isRotating = true;
            StartCoroutine(Rotate(Vector3.up, 45, 1.0f));
        }
    }

    public void RotateRight()
    {
        if (isRotating == false)
        {
            isRotating = true;
            StartCoroutine(Rotate(Vector3.up, -45, 1.0f));
        }
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
        isRotating = false;
    }


}
