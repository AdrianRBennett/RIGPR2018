using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // PUBLIC MEMBERS

    public UnityEngine.UI.Text customDebugText;         // A debug text object that displays the latest spoken words.
    public bool customDebugTextOn;                      // A flag to control the display of the debug text.

    // PRIVATE MEMBERS

    private Player playerRef;                           // A reference to the player object.
    private SceneData sceneDataRef;                     // A reference to the scene data. Needed for current command list so will need to be assigned a new value for each scene.
    private string latestCommand;                       // Holds the latest spoken command.
    private Item latestItem;                            // Holds the latest spoken item.
    private ItemPosition latestItemPos;
    private string[] latestInputWordList;               // A string array containing the latest spoken words.
    private char[] splittingCharacters = new char[] {	// The input string is split at each instance of these characters.
		' '
    };

    private int DEBUGVAR = 0;
    private string[] DEBUGCOMMANDS = new string[] {
        "place a",
        "rotate",
        "flip",
        "flip",
        "flip",
        "place a"
    };

    void Start()
    {
        /*
			Initialisation function. 
		*/
        latestInputWordList = new string[] {
            "default"
        };
        playerRef = FindObjectOfType<Player>();
        sceneDataRef = FindObjectOfType<SceneData>();
    }

    void Update()
    {
        /*
			Update function. 
		*/
        customDebugText.text = "";
        if (customDebugTextOn)
        {
            for (int i = 0; i < latestInputWordList.Length; i++)
            {
                customDebugText.text += latestInputWordList[i] + " ";
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            ProcessInput(DEBUGCOMMANDS[DEBUGVAR]);

            if (DEBUGVAR < (DEBUGCOMMANDS.Length - 1))
                DEBUGVAR++;
            else
                DEBUGVAR = 0;
        }
    }

    // PUBLIC METHODS

    public void ProcessInput(string input)
    {
        /*
			A function to be called by the input source.
			It calls the necessary functions to identify functions from spoken words and send corresponding commands to the correct items.
		*/
        latestInputWordList = SplitInputToWordList(input);
        IdentifyCommandsAndItems(sceneDataRef);
        SendCommand();
    }

    // PRIVATE METHODS

    private string[] SplitInputToWordList(string input)
    {
        /*
			 Splits the input string into a string array of individual words and assigns the result to latestInputWordList.
		*/
        return input.Split(splittingCharacters);
    }

    private void IdentifyCommandsAndItems(SceneData data)
    {
        /*
			Iterates through the list of latest spoken words and checks if each of them are commands or items.
			Commands are identified by comparing the input words to the current list of available commands and their alternative names.
			Items are identified by comparing the input words to the available items at the player's current position and their alternative names.
			Only the latest spoken command and item will be remembered by the system at the end of the function.
		*/

        latestCommand = "";
        latestItem = null;
        latestItemPos = null;
        ItemPosition[] itemPosToCheck = playerRef.position.AvailableItemPos;

        if (latestInputWordList[0] == "place")
        {
            int e = 0;
        }

        for (int i = 0; i < latestInputWordList.Length; i++)
        {               // Iteration through word input
            for (int i2 = 0; i2 < data.commandList.Length; i2++)
            {               // Iteration through command list
                for (int i3 = 0; i3 < data.commandList[i2].names.Length; i3++)
                {   // Iteration through command names
                    if (data.commandList[i2].names[i3] == latestInputWordList[i])
                    {   // Check if command name matches matches input word
                        SetLatestCommand(data.commandList[i2].GetIdentifier());
                    }
                }
            }
            for (int i2 = 0; i2 < itemPosToCheck.Length; i2++)
            {               // Iteration through accessible item positions
                for (int i3 = 0; i3 < itemPosToCheck[i2].GetNames().Length; i3++)
                {
                    if (itemPosToCheck[i2].GetNames()[i3] == latestInputWordList[i] && itemPosToCheck[i2].canBePlacedIn)
                    {
                        SetLatestItemPos(itemPosToCheck[i2]);
                    }
                }
                if (itemPosToCheck[i2].heldItem != null)
                {
                    for (int i3 = 0; i3 < itemPosToCheck[i2].heldItem.names.Length; i3++)
                    {   // Iteration through item names
                        if (itemPosToCheck[i2].heldItem.names[i3] == latestInputWordList[i])
                        {   // Check if item name matches input word.
                            SetLatestItem(itemPosToCheck[i2].heldItem);
                        }
                    }
                }
            }
        }
    }

    private void SetLatestCommand(string command)
    {
        latestCommand = command;
    }

    private void SetLatestItem(Item item)
    {
        latestItem = item;
        latestItemPos = null;
    }

    private void SetLatestItemPos(ItemPosition itemPos)
    {
        latestItemPos = itemPos;
        latestItem = null;
    }

    private void SendCommand()
    {
        /*
			In the case that both an item or item position and a command were spoken in the previous sentence, the lastest spoken item or item position is sent the latest spoken command.
		*/

        if (latestItem != null && latestCommand != string.Empty)
        {                           // Command sent to non-held item.
            latestItem.TakeCommand(latestCommand);

        }
        else if (latestItemPos != null && latestItemPos.heldItem == null && latestCommand == CommandPlace.identifier)
        {   // Place command sent to item position.
            if (playerRef.heldItem != null)
                playerRef.heldItem.BePlaced(latestItemPos);
            else
                Debug.Log("The player cannot place an item when they are holding nothing.");

        }
        else if (latestItem == null && latestCommand != string.Empty && playerRef.heldItem != null)
        {   // Command sent to player's held item.
            playerRef.heldItem.TakeCommand(latestCommand);
        }
    }
}