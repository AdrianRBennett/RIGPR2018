using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Item
{
    private bool isRotating = false;

    //protected const string RotateName = CommandRotate.identifier;
    //
    //protected const string RotateL = CommandLeft.identifier;
    //
    //protected const string RotateR = CommandRight.identifier;

    protected CommandRotate cRotate = new CommandRotate();

    protected CommandLeft cRotateL = new CommandLeft();

    protected CommandRight cRotateR = new CommandRight();

    public override void TakeCommand(string commandName)
    {
        base.TakeCommand(commandName);

        foreach(string name in cRotate.names)
        {
            if(name == commandName)
            {
                RotateInit(45);
                break;
            }
        }

        

        foreach (string name in cRotateL.names)
        {
            if (name == commandName)
            {
                RotateInit(45);
                break;
            }
        }

        foreach (string name in cRotateR.names)
        {
            if (name == commandName)
            {
                RotateInit(-45);
                break;
            }
        }

        //switch (commandName)
        //{
        //    case RotateName:
        //        RotateInit(45);
        //        break;
        //    case RotateL:
        //        RotateInit(45);
        //        break;
        //    case RotateR:
        //        RotateInit(-45);
        //        break;
        //}
    }

    protected override void InitNames()
    {
        names = new string[] {
            "mirror",
            "Mirror",
            "mira",
            "Mira",
            "mera",
            "Mera",
            "meara",
            "Meara",
            "mana",
            "similar",
            "Miro",
            "Meryal",
            "mayor",
            "Zero",
            "zero",
            "0",
            "maya",
            "Maya",
            "muda",
            "era",
            "mirar",
            "mirage",
            "mayer",
            "meyer"
        };
    }

    public void RotateInit(int angle)
    {
        if (isRotating == false)
        {
            isRotating = true;
            StartCoroutine(Rotate(-Vector3.forward, angle, 1.0f));
        }
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
        isRotating = false;
    }
}
