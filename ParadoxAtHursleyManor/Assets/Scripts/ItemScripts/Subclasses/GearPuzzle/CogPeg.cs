using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPeg : Item
{
    public string pegID;

    protected CommandPlace cPlace = new CommandPlace();

    protected override void InitNames()
    {
        if (names.Length == 0)
        {
            names = new string[] {
            pegID,
            "slot",
            "here",
            "axis",
            "axle"
            };
        }
        else
        {
            
            string[] extraIDs = new string[]
            {
                "slot",
                "here",
                "axis",
                "axle"
            };

            List<string> listOfNames = new List<string>();
            listOfNames.Add(pegID);

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
            }
        }

    }

    public void PlaceCog()
    {
        if(playerRef.heldItem != null && playerRef.heldItem.GetComponent<Cog>() != null)
        {
            if(playerRef.heldItem.GetComponent<Cog>().cogID == pegID)
            {
                playerRef.heldItem.GetComponent<Cog>().itemHolder = gameObject;
                
                playerRef.heldItem = null;
            }
        } else
        {
            Debug.Log("Wrong Peg");
        }
    }
}
