using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Handling : MonoBehaviour {


    public Material blankScreen;
    public Material mainScreen;
    public Material highlightScreen;

    private bool highlihtScreenOn = false;

    public bool mainScreenOn = false;

	// Use this for initialization
	void Start () {
        SetMat(blankScreen);
    }
	
	// Update is called once per frame
	void Update () {

        if(mainScreenOn == true)
        {
            highlihtScreenOn = false;
            SetMat(mainScreen);

        } else if (highlihtScreenOn == true) {
            SetMat(highlightScreen);
            highlihtScreenOn = false;
        } else
        {
            SetMat(blankScreen);
        }
	}

    public void highlight()
    {
       if(mainScreenOn == false)
        {
            highlihtScreenOn = true;
        }
    }


    private void SetMat(Material newMat)
    {
        GetComponent<Renderer>().material = newMat;
    }

}
