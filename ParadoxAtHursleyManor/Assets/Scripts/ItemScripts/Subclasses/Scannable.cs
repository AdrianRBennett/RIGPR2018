using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : Item {

    private GameObject scanBoard;

    public string identifier;

    public bool highlight = false;

    public Shader highlighted;

    public string description;

    private Shader main;

    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        main = rend.material.shader;
        scanBoard = GameObject.Find("Scan_Board");
    }

    protected const string Scan = CommandScan.identifier;

    public override void TakeCommand(string commandName)
    {
        if(commandName == Scan)
        {
            ScanThis();
        }
    }

    protected override void InitNames()
    {
        if (names.Length < 1)
        {
            names = new string[] {
            identifier
            };
        }

        if (identifier == "")
        {
            identifier = names[0];
        }
    }

    private void Update()
    {
        if (highlight == true)
        {
            highlight = false;
            rend.material.shader = highlighted;
        }
        else
        {
            rend.material.shader = main;
        }
    }

    public void ScanThis() {
        scanBoard.GetComponent<ScanBoard_Script>().ChangeText(identifier, description, transform);
    }
}
