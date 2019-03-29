using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCog : MonoBehaviour {

    public GameObject cogBlue;
    public GameObject cogRed;

    public GameObject pegBlue;
    public GameObject pegRed;

    public GameObject pos1;
    public GameObject pos2;


    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.T))
        {
            cogBlue.GetComponent<Cog>().Pickup();
        }
        if (Input.GetKey(KeyCode.Y))
        {
            cogRed.GetComponent<Cog>().Pickup();
        }


        if (Input.GetKey(KeyCode.G))
        {
            pegBlue.GetComponent<CogPeg>().PlaceCog();
        }
        if (Input.GetKey(KeyCode.H))
        {
            pegRed.GetComponent<CogPeg>().PlaceCog();
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.position = pos1.transform.position;
            GetComponent<Player>().position = pos1.GetComponent<PlayerPosition>();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = pos2.transform.position;
            GetComponent<Player>().position = pos2.GetComponent<PlayerPosition>();
        }
    }
}
