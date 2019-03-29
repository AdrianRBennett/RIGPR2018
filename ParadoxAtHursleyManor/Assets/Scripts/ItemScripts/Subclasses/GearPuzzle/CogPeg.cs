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
            "axis",
            "axle"
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
                break;
            }
        }

    }

    public void PlaceCog()
    {
        bool breakLoop = false;
        bool placed = false;
        if(playerRef.heldItem != null && playerRef.heldItem.GetComponent<Cog>() != null)
        {

            foreach(string pegName in names)
            {
                if (breakLoop == true)
                {
                    Debug.Log("Loop had been broken");
                    break;
                }

                foreach (string cogName in playerRef.heldItem.GetComponent<Cog>().names)
                {
                    if(pegName == cogName)
                    {
                        PlaceCode();
                        breakLoop = true;
                        placed = true;
                        break;
                    }
                }
                
            }
  
        } 
        if(placed == false)
        {
            Debug.Log("Wrong Cog");
        }
    }

    private void PlaceCode()
    {
        playerRef.heldItem.GetComponent<Cog>().itemHolder = gameObject;
        playerRef.heldItem.GetComponent<Cog>().onPeg = true;
        playerRef.heldItem = null;

        for(int i = 0; i < playerRef.position.AvailableItemPos.Length; i++)
        {
            if(playerRef.position.AvailableItemPos[i] == GetComponent<ItemPosition>())
            {
                playerRef.position.AvailableItemPos[i] = new ItemPosition();
            }
        }
    }
}
