using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artefact : Item {

    
    public int ID;

    protected const string pickupName = CommandPickUp.identifier;

    public override void TakeCommand(string commandName)
    {
        base.TakeCommand(commandName);

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
        
        if (names.Length == 0)
        {
            names = new string[] {
            identifier,
            "artefact",
            "item",
            "gizmo"
            };
        }
        else
        {

            string[] extraIDs = new string[]
            {
                "artefact",
                "item",
                "gizmo"
            };

            List<string> listOfNames = new List<string>();
            listOfNames.Add(identifier);

            foreach (string name in names)
            {
                listOfNames.Add(name);
            }

            listOfNames.AddRange(extraIDs);

            names = listOfNames.ToArray();
        }
    }

    public void PickUpArtefact()
    {
        GameObject.Find("ArtefactHandler").GetComponent<ArtefactHandler>().ArtefactInit(ID);
        gameObject.SetActive(false);
    }
}
