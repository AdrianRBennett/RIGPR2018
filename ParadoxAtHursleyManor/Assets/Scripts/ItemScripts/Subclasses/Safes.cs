using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safes : Item {

    protected CommandOpen cOpen = new CommandOpen();

    public GameObject housedObject;

    private bool opened = false;

    private void Awake()
    {
        housedObject.SetActive(false);
        transform.Rotate(Vector3.forward, 358);
    }

    protected override void InitNames()
    {
        if (names.Length == 0)
        {
            names = new string[] {
            "safe",
            "snaf"
            };
        }
        else
        {

            string[] extraIDs = new string[]
            {
                "safe",
                "snaf"
            };

            List<string> listOfNames = new List<string>();
            

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

        foreach (string name in cOpen.names)
        {
            if (name == commandName)
            {
                if (!opened)
                {
                    opened = true;
                    StartCoroutine("OpenSafe");
                }
                //PlaceCog();
                break;
            }
        }
    }

    //private void Update()
    //{
    //    if(Input.GetKey(KeyCode.O) && !opened)
    //    {
    //        Debug.Log("Its doing something");
    //        opened = true;
    //        StartCoroutine("OpenSafe");
    //    }
    //}

    IEnumerator OpenSafe()
    {
        for(int i = 0; i < 10; i++)
        {
            transform.Rotate(-Vector3.forward * (100 * Time.deltaTime));
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(2.0f);
        housedObject.SetActive(true);
        //while (transform.localEulerAngles.z > 190.0f)
        //{
        //    
        //}

        yield return null;
    }
}

