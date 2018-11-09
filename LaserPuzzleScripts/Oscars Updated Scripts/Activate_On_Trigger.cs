using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_On_Trigger : MonoBehaviour {

    public Material newMat;



    public void ChangeMaterial()
    {
        GetComponent<Renderer>().material = newMat;
    }
}
