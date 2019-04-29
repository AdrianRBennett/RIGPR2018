using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : Item
{
    public string cogID;

    public bool onPeg = false;

    public GameObject itemHolder;

    private bool beingHeld = false;

    protected CommandPickUp cPickup = new CommandPickUp();

    protected override void InitNames()
    {
        if (names.Length == 0)
        {
            names = new string[] {
            cogID,
            "gear",
            "Gear",
            "cog",
            "Cog",
            "give",
            "Give",
            "yeah",
            "Yeah",
            "gay",
            "Gay"
            };
        }
        else
        {

            string[] extraIDs = new string[]
            {
                "gear",
                "Gear",
                "cog",
                "Cog",
                "give",
                "Give",
                "yeah",
                "Yeah",
                "gay",
                "Gay"
            };

            List<string> listOfNames = new List<string>();
            listOfNames.Add(cogID);

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
        if(playerRef.heldItem == null && onPeg != true)
        {
            playerRef.heldItem = this;
            beingHeld = true;

            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().Stop();
            }

            FindObjectOfType<AudioManager>().Play("pickup");
        }
    }

    private void Update()
    {
        if(beingHeld == true)
        {
            if(onPeg == true)
            {
                transform.position = itemHolder.transform.position;
                transform.rotation = itemHolder.transform.rotation;
            } else
            {
                transform.position = itemHolder.transform.position - (Vector3.up * 1.5f);
                transform.Rotate(5.0f, 5.0f, 5.0f);
            }
        }
    }
}
