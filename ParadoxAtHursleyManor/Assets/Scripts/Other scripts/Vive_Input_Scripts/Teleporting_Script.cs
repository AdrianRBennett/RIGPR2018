using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;

public class Teleporting_Script : MonoBehaviour {

    public GameObject cameraRig;

    public SteamVR_Action_Boolean teleport;

    public Transform rightHand;

    public GameObject controlRay;

    public float fadeTime = 0.5f;

    private RaycastHit rayHit;

    private bool isTeleporting = false;

    private int nextIndex;

    private GameObject[] telepads;
    private GameObject[] telepadsNS;

    // Use this for initialization
    void Start () {
        SteamVR_Fade.View(Color.black, 0);
        SteamVR_Fade.View(Color.clear, fadeTime * 4);

        telepads = GameObject.FindGameObjectsWithTag("Telepad");
        telepadsNS = GameObject.FindGameObjectsWithTag("Telepad_NS");

        if (PlayerPrefs.HasKey("Index"))
        {
            NewScene();
        }

        TelepadVisible(false);


        //if (GameObject.Find("Position_Tracker").GetComponent<Position_Tracking>().posIndex[SceneManager.GetActiveScene().buildIndex] > 0)
        //{
        //    NewScene();
        //}
    }
	
	// Update is called once per frame
	void Update () {
        if (teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            controlRay.SetActive(true);
            //Debug.DrawLine(rightHand.position, (rightHand.position + rightHand.forward * 10.0f), Color.blue);
            if (Physics.Raycast(rightHand.position, (-rightHand.up), out rayHit))
            {
                controlRay.transform.position = rightHand.position + ((rayHit.point - rightHand.position) * 0.5f);
                controlRay.transform.LookAt(rayHit.point);
                controlRay.transform.Rotate(Vector3.right, 90.0f);
                controlRay.transform.localScale = new Vector3(controlRay.transform.localScale.x, rayHit.distance * 0.5f, controlRay.transform.localScale.z);
                TelepadVisible(true);

            }
        } else if(teleport.GetStateUp(SteamVR_Input_Sources.RightHand) && isTeleporting == false)
        {            
            switch (rayHit.collider.tag)
            {
                case "Telepad":
                    StartCoroutine("TeleportRig");
                    break;
                case "Telepad_NS":
                    nextIndex = rayHit.collider.gameObject.GetComponent<Telepad_NS>().teleIndex;
                    StartCoroutine("TeleportScene", rayHit.collider.gameObject.GetComponent<Telepad_NS>().sceneIndex);
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
        cameraRig.transform.position = rayHit.collider.gameObject.transform.position;

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

        //GameObject.Find("Position_Tracker").GetComponent<Position_Tracking>().posIndex[SceneIndex] = nextIndex;
        //GameObject.Find("Position_Tracker").GetComponent<Position_Tracking>().positions[SceneManager.GetActiveScene().buildIndex] = cameraRig.transform.position;
        SceneManager.LoadScene(SceneIndex);

    }


    
}
