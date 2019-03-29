using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegArray : Item {

    public GameObject door;

    public GameObject artefact;

    public GameObject[] pegs = new GameObject[5];

    public bool[] gearsCollected = new bool[5];

    protected CommandPlace cPlace = new CommandPlace();

    protected override void InitNames()
    {
        if (names.Length == 0)
        {
            names = new string[] {

            "slot",
            "axis",
            "axle",
            };
        }
        else
        {

            string[] extraIDs = new string[]
            {
                "slot",
                "axis",
                "axle"
            };

            List<string> listOfNames = new List<string>();

            foreach (string name in names)
            {
                listOfNames.Add(name);
            }

            listOfNames.AddRange(extraIDs);

            names = listOfNames.ToArray();
        }
    }

    public override void TakeCommand(string commandName)
    {
        base.TakeCommand(commandName);

        foreach (string name in cPlace.names)
        {
            if (name == commandName)
            {
                PlaceCog();
                break;
            }
        }

    }

    private void PlaceCog()
    {
        bool placed = false;

        if (playerRef.heldItem != null && playerRef.heldItem.GetComponent<Cog>() != null)
        {

            for (int i = 0; i < pegs.Length; i++)
            {
                if (pegs[i].GetComponent<CogPeg>().pegID == playerRef.heldItem.GetComponent<Cog>().cogID)
                {
                    playerRef.heldItem.GetComponent<Cog>().itemHolder = pegs[i];
                    playerRef.heldItem.GetComponent<Cog>().onPeg = true;
                    playerRef.heldItem = null;

                    gearsCollected[i] = true;
                    if(gearsCollected[0] && gearsCollected[1] && gearsCollected[2] && gearsCollected[3] && gearsCollected[4]){
                        StartCoroutine("FinishPuzzle");
                    }
                    placed = true;
                    break;
                }
            }
        }
        if(placed == false)
        {
            Debug.Log("No gear found");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && door.transform.localEulerAngles.z > 136.0f)
        {
            //door.transform.Rotate(-Vector3.forward * (100 * Time.deltaTime));
            StartCoroutine("FinishPuzzle");
        }
    }

    IEnumerator FinishPuzzle()
    {
        while (door.transform.localEulerAngles.z > 136.0f)
        {
            door.transform.Rotate(-Vector3.forward * (100 * Time.deltaTime));
            yield return new WaitForSeconds(0.01f);
        }
        
        artefact.SetActive(true);
        artefact.GetComponent<Rigidbody>().AddForce(((transform.up * 3) + transform.forward) * 150.0f);
        yield return null;
    }
    
}
