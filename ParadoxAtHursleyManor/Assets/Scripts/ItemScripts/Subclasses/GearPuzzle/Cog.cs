using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : Item
{
    public string cogID;

    public GameObject itemHolder;

    private bool beingHeld = false;

    protected CommandPickUp cPickup = new CommandPickUp();

    protected override void InitNames()
    {
        names = new string[] {
            cogID,
            "gear",
            "cog",
            "give",
            "yeah"
        };
    }


    public override void TakeCommand(string commandName)
    {
        base.TakeCommand(commandName);
        
        foreach(string name in cPickup.names)
        {
            if(name == commandName)
            {
                Pickup();
            }
        }

    }


    public void Pickup()
    {
        if(playerRef.heldItem == null)
        {
            playerRef.heldItem = this;
            beingHeld = true;
        }
    }

    private void Update()
    {
        if(beingHeld == true)
        {
            //transform.position = itemHolder.transform.position - (Vector3.up * 1);
        }
    }
}
