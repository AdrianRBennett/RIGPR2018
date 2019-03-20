using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artefact : Item {

    public string identifier;
    public int ID;

    protected const string pickupName = CommandPickUp.identifier;

    public override void TakeCommand(string commandName)
    {
        switch (commandName)
        {
            case pickupName:
                PickUpArtefact();
                break;
            default:
                break;
        }
    }

    protected override void InitNames()
    {
        names = new string[] {
            "artefact",
            identifier,
            "item",
            "gizmo"
        };
    }

    public void PickUpArtefact()
    {
        GameObject.Find("ArtefactHandler").GetComponent<ArtefactHandler>().ArtefactInit(ID);
        gameObject.SetActive(false);
    }
}
