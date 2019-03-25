using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;

public class Teleporting_Script : MonoBehaviour {

    public bool debugControl = false;
    public float fadeTime = 0.5f;

    public GameObject cameraRig;
    public Transform rightHand;
    public GameObject controlRay;


    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean rotateL;
    public SteamVR_Action_Boolean rotateR;
    public SteamVR_Action_Boolean pickUP;
    public SteamVR_Action_Boolean scan;


    private GameObject[] telepads;
    private GameObject[] telepadsNS;
    
    private int nextIndex;

    private RaycastHit rayHit;

    private bool isTeleporting = false;

    private Vector3 newPosition;


    // Use this for initialization
    void Start () {
        SteamVR_Fade.View(Color.black, 0);
        SteamVR_Fade.View(Color.clear, fadeTime * 4);

        telepads = GameObject.FindGameObjectsWithTag("Telepad");
        telepadsNS = GameObject.FindGameObjectsWithTag("Telepad_NS");

        if (PlayerPrefs.HasKey("Index"))
        {
            if(PlayerPrefs.GetInt("Index") != 0)
            {
                NewScene();
            }
        }

        TelepadVisible(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            controlRay.SetActive(true);
            if (Physics.Raycast(rightHand.position, (rightHand.forward - rightHand.up), out rayHit))
            {
                controlRay.transform.position = rightHand.position + ((rayHit.point - rightHand.position) * 0.5f);
                controlRay.transform.LookAt(rayHit.point);
                controlRay.transform.Rotate(Vector3.right, 90.0f);
                controlRay.transform.localScale = new Vector3(controlRay.transform.localScale.x, rayHit.distance * 0.5f, controlRay.transform.localScale.z);
                TelepadVisible(true);

                if(rayHit.collider.GetComponent<Item>() != null)
                {
                    rayHit.collider.GetComponent<Item>().highlight = true;
                }

            }
        } else if(teleport.GetStateUp(SteamVR_Input_Sources.RightHand) && isTeleporting == false)
        {   
            if(rayHit.collider.GetComponent<Item>() != null && scan.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                rayHit.collider.GetComponent<Item>().ScanThis();
                // SCAN CODE GO HERE!
            }

            switch (rayHit.collider.tag)
            {
                case "Telepad":
                    newPosition = rayHit.collider.gameObject.transform.position;
                    StartCoroutine("TeleportRig");
                    break;
                case "Telepad_NS":
                    nextIndex = rayHit.collider.gameObject.GetComponent<Telepad_NS>().teleIndex;
                    StartCoroutine("TeleportScene", rayHit.collider.gameObject.GetComponent<Telepad_NS>().sceneIndex);
                    break;
                case "Mirror":
                    if (rotateL.GetStateUp(SteamVR_Input_Sources.RightHand) && debugControl)
                    {
                        rayHit.collider.gameObject.GetComponent<Mirror>().RotateInit(45);
                    }
                    else if (rotateR.GetStateUp(SteamVR_Input_Sources.RightHand) && debugControl)
                    {
                        rayHit.collider.gameObject.GetComponent<Mirror>().RotateInit(-45);
                    }
                    break;
                case "Artefact":
                    if (pickUP.GetStateUp(SteamVR_Input_Sources.RightHand) && debugControl) {
                        rayHit.collider.gameObject.GetComponent<Artefact>().PickUpArtefact();
                    }
                    break;
                default:
                    break;
            }
            TelepadVisible(false);
                
        } else {
            controlRay.SetActive(false);
        }
	}

    private void NewScene()
    {
        for (int i = 0; i < telepadsNS.Length; i++)
        {
            if (telepadsNS[i].GetComponent<Telepad_NS>().teleIndex == PlayerPrefs.GetInt("Index",0))
            {
                cameraRig.transform.position = telepadsNS[i].transform.position;
                PlayerPrefs.DeleteKey("Index");
                break;
            }
        }
    }

    private void TelepadVisible(bool visible) {
        foreach (GameObject telepad in telepads)
        {
            if(telepad.transform.position != cameraRig.transform.position)
            {
                telepad.SetActive(visible);
            } else
            {
                telepad.SetActive(false);
            }

        }
        foreach (GameObject telepad in telepadsNS)
        {
            if (telepad.transform.position != cameraRig.transform.position)
            {
                telepad.SetActive(visible);
            } else
            {
                telepad.SetActive(false);
            }
        }
    }

    private IEnumerator TeleportRig()
    {
        isTeleporting = true;

        SteamVR_Fade.View(Color.black, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        cameraRig.transform.position = newPosition;

        newPosition = Vector3.zero;

        SteamVR_Fade.View(Color.clear, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        isTeleporting = false;

    }

    private IEnumerator TeleportScene(int SceneIndex)
    {
        isTeleporting = true;


        SteamVR_Fade.View(Color.black, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        PlayerPrefs.SetInt("Index", nextIndex);

        
        SceneManager.LoadScene(SceneIndex);

    }


    
}
