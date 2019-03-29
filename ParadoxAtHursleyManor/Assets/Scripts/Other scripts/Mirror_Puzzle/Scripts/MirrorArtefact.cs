using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorArtefact : MonoBehaviour {

    public bool active = false;

    public GameObject plant;

    public GameObject artefact;

    private GameObject player;

    public GameObject telepad;

    public void Activate()
    {
        if (!active && (player.GetComponent<Player>().position == telepad.GetComponent<PlayerPosition>()))
        {
            active = true;
            StartCoroutine("PlantActive");
        }
    }

    

    // Use this for initialization
    void Start () {
        player = GameObject.Find("[CameraRig]");
        //telepad = GameObject.Find("Telepad (79)");
	}
	
    // Starting Scale:  0.04
    // End Scale:       0.12
    // Scale change:    0.08

    IEnumerator PlantActive()
    {
        float scaleInc = 0.08f / 500f;
        Vector3 scaleV = new Vector3(scaleInc, scaleInc, scaleInc);

        for(int i = 0; i < 500; i++)
        {
            plant.transform.localScale += scaleV;
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(1.0f);
        artefact.SetActive(true);

        yield return null;
    }
    
	// Update is called once per frame
	void Update () {
        
	}
}
