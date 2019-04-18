using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;

public class Teleporting_Script : MonoBehaviour {

    // GameObjects and Transform
    public GameObject WatsonPref;
    public GameObject controlRay;

    private GameObject WatsonRef;
    private GameObject VSon;
    private GameObject[] telepadsNS;
    private GameObject[] telepads;

    public Transform rightHand;


    // Input buttons
    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean rotateL;
    public SteamVR_Action_Boolean rotateR;
    public SteamVR_Action_Boolean pickUP;
    public SteamVR_Action_Boolean scan;
    public SteamVR_Action_Boolean pause;
    public SteamVR_Action_Boolean reset;


    //Misc

    public bool debugControl = false;

    private bool isTeleporting = false;
    private bool paused;


    private RaycastHit rayHit;

    public float fadeTime = 0.5f;

    private float resetCount = 0.0f;


    private Vector3 newPosition;
    

    private int nextIndex;


    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("Height"))
        {
            transform.localScale = new Vector3(transform.localScale.x, PlayerPrefs.GetFloat("Height"), transform.localScale.z);
        }
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

        
        WatsonRef = GameObject.Find("Watson_Obj");

        VSon = GameObject.Find("Vson");

        TelepadVisible(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (pause.GetStateDown(SteamVR_Input_Sources.Any))
        {
            if(paused == false)
            {
                paused = true;
            } else
            {
                paused = false;
            }
        }

        if (paused == false)
        {

            if (reset.GetState(SteamVR_Input_Sources.Any))
            {
                resetCount += Time.deltaTime;

                if (reset.GetState(SteamVR_Input_Sources.Any) && resetCount >= 3.0f)
                {
                    Debug.Log("Resetting Watson");
                    Destroy(WatsonRef);
                    VSon.GetComponentInChildren<VSon_Faces>().StopAllCoroutines();
                    WatsonRef = Instantiate(WatsonPref);
                    WatsonRef.name = "Watson_Obj";
                    VSon.GetComponentInChildren<VSon_Faces>().ResetWatson();
                    resetCount = 0.0f;
                }
            } else
            {
                resetCount = 0.0f;
            }




            if (teleport.GetState(SteamVR_Input_Sources.RightHand))
            {
                controlRay.SetActive(true);

                // Create raycast from controller.
                if (Physics.Raycast(rightHand.position, (rightHand.forward - rightHand.up), out rayHit))
                {

                    // Draw ray from controller
                    controlRay.transform.position = rightHand.position + ((rayHit.point - rightHand.position) * 0.5f);
                    controlRay.transform.LookAt(rayHit.point);
                    controlRay.transform.Rotate(Vector3.right, 90.0f);
                    controlRay.transform.localScale = new Vector3(controlRay.transform.localScale.x, rayHit.distance * 0.5f, controlRay.transform.localScale.z);
                    TelepadVisible(true);

                    // Highlight item objects
                    if (rayHit.collider.GetComponent<Item>() != null)
                    {
                        rayHit.collider.GetComponent<Item>().highlight = true;
                    }

                }
            }
            else if (teleport.GetStateUp(SteamVR_Input_Sources.RightHand) && isTeleporting == false)
            {
                /*
                if(rayHit.collider.GetComponent<Item>() != null && scan.GetStateUp(SteamVR_Input_Sources.RightHand))
                {
                    rayHit.collider.GetComponent<Item>().ScanThis();
                    // SCAN CODE GO HERE!
                }
                */

                // Teleport code here.
                if (rayHit.collider.tag == "Telepad")
                {
                    GetComponent<Player>().position = rayHit.collider.gameObject.GetComponent<PlayerPosition>();
                    newPosition = rayHit.collider.gameObject.transform.position;
                    StartCoroutine("TeleportRig");

                } // Debug controls here.
                else if (debugControl == true)
                {
                    switch (rayHit.collider.tag)
                    {
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
                            if (pickUP.GetStateUp(SteamVR_Input_Sources.RightHand) && debugControl)
                            {
                                rayHit.collider.gameObject.GetComponent<Artefact>().PickUpArtefact();
                            }
                            break;
                        default:
                            break;
                    }
                }

                TelepadVisible(false);

            }
            else
            {
                controlRay.SetActive(false);
            }
        }
        else
        {

        }

    }

    private void NewScene()
    {
        for (int i = 0; i < telepadsNS.Length; i++)
        {
            if (telepadsNS[i].GetComponent<Telepad_NS>().teleIndex == PlayerPrefs.GetInt("Index",0))
            {
                transform.position = telepadsNS[i].transform.position;
                PlayerPrefs.DeleteKey("Index");
                break;
            }
        }
    }

    private void TelepadVisible(bool visible) {
        foreach (GameObject telepad in telepads)
        {
            if(telepad.transform.position != transform.position)
            {
                telepad.SetActive(visible);
            } else
            {
                telepad.SetActive(false);
            }

        }
        foreach (GameObject telepad in telepadsNS)
        {
            if (telepad.transform.position != transform.position)
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
        transform.position = newPosition;

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

    private IEnumerator QuitGame()
    {
        SteamVR_Fade.View(Color.black, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        Debug.Log("Quit");

        Application.Quit();
    }


    
}
