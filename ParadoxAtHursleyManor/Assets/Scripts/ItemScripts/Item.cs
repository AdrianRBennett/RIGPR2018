using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    /*
		An abstract class that all items in the game should inherit from.

        Includes commands and items for scanning.
	*/

    // PUBLIC MEMBERS

    private GameObject scanBoard;

    private Shader mainShader;
    public Shader highShader;

    public bool highlight = false;

    private Renderer rend;

    public string description;

    protected CommandScan cScan = new CommandScan();

    public string identifier;
    public string[] names;									// An array of words that this item can be identified with.
	public ItemPosition basePos = null;					// An item's initial position.

	// PROTECTED MEMBERS

	protected ItemPosition position = null;					// An item's current position.
	protected Player playerRef;								// A reference to the player object.

	protected void Start() {
		position = GetComponentInParent<ItemPosition> ();
		playerRef = FindObjectOfType<Player> ();
		InitNames ();

        rend = GetComponent<Renderer>();
        
        mainShader = rend.material.shader;



        scanBoard = GameObject.Find("Scan_Board");
    }

	// PUBLIC METHODS

	public virtual void ReturnToBasePos () {
		/*
			Returns this item to its base position.
		*/ 
		basePos.heldItem = this;
		position = basePos;
	}
    public virtual void TakeCommand(string commandName) {
        foreach (string name in cScan.names)
        {
            if (name == commandName)
            {
                ScanThis();
                break;
            }
        }
    }   // A virtual function which needs to be overwritten with the base command 

    public virtual void BePlaced (ItemPosition newPos)	{	// Should be overidden by placeable objects with placement functionality. 	
		Debug.Log("No placement functionality for this Item");
	}


    private void Update()
    {
        if (highlight == true)
        {
            highlight = false;
            rend.material.shader = highShader;
        }
        else if(mainShader != null)
        {
            rend.material.shader = mainShader;
        }
    }

    public void ScanThis() {
        scanBoard.GetComponent<ScanBoard_Script>().ChangeText(identifier, description, transform);
    }

	// PROTECTED METHODS

	protected abstract void InitNames ();					// Initialises the name list of the Item.
}
