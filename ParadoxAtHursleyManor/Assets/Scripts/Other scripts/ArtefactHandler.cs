using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactHandler : MonoBehaviour {

    private bool MirrorA = false;
    private bool GearA = false;

    public int Artefacts;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        Artefacts = 0;
    }

    public void ArtefactInit(int artefact)
    {
        if(artefact == 1)
        {
            MirrorArtefact();
        } if (artefact == 2)
        {
            GearArtefact();
        }
    }

    public void MirrorArtefact()
    {
        if (!MirrorA) {
            MirrorA = true;
            Artefacts += 1;
        }

    }

    public void GearArtefact()
    {
        if (!GearA){ 
            GearA = true;
            Artefacts += 2;
        }
    }
}
