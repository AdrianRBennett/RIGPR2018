using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasmentArtefacts : MonoBehaviour {

    public GameObject ArtefactsM;

    public GameObject ArtefactsG;

	// Use this for initialization
	void Start () {
        ArtefactsM.SetActive(false);
        ArtefactsG.SetActive(false);

        if (GameObject.Find("ArtefactHandler") != null)
        {
            switch (GameObject.Find("ArtefactHandler").GetComponent<ArtefactHandler>().Artefacts)
            {
                case 1:
                    ArtefactsM.SetActive(true);
                    break;
                case 2:
                    ArtefactsG.SetActive(true);
                    break;
                case 3:
                    ArtefactsM.SetActive(true);
                    ArtefactsG.SetActive(true);
                    break;
                default:
                    break;
            }
        }
	}
}
