using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;
using UnityEngine.SceneManagement;

public class Start_Scene_Script : MonoBehaviour {

    public GameObject controlRay;

    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean left;
    public SteamVR_Action_Boolean right;

    public Transform rightHand;

    private RaycastHit rayHit;

    public GameObject StartS;
    public GameObject OptionsS;
    public GameObject QuitS;

    private bool quitting;
    private bool options;

    public float fadeTime = 0.5f;

    private float defaultHeight;

    // Use this for initialization
    void Start () {
        defaultHeight = transform.localScale.y;
        if (PlayerPrefs.HasKey("Height"))
        {
            PlayerPrefs.DeleteKey("Height");
        }
	}
	
	// Update is called once per frame
	void Update () {
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
                
            }
        }
        else if (teleport.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            if(rayHit.collider.name == "Quit")
            {
                if (quitting == false && options == false)
                {
                    quitting = true;
                    OptionsS.GetComponentInChildren<TextMeshPro>().text = "Are you sure?";
                    StartS.GetComponentInChildren<TextMeshPro>().text = "YES";
                    QuitS.GetComponentInChildren<TextMeshPro>().text = "NO";

                }
                else if (quitting == true && options == false)
                {
                    ResetScreens();
                    quitting = false;
                }
                else if (quitting == false && options == true)
                {
                    ResetScreens();
                    options = false;
                }
            }
            else if (rayHit.collider.name == "Start")
            {
                if (quitting == false && options == false)
                {
                    StartCoroutine("StartGame");
                }
                //else if (quitting == true && options == false)
                //{
                //    
                //}
                //else if (quitting == false && options == true)
                //{
                //    
                //}
            }
            else if (rayHit.collider.name == "Options")
            {
                if (quitting == false && options == false)
                {
                    options = true;
                    OptionsS.GetComponentInChildren<TextMeshPro>().text = "Adjust your height with the measuring stick";
                    StartS.GetComponentInChildren<TextMeshPro>().text = "Use left and right on the D-Pad";
                    QuitS.GetComponentInChildren<TextMeshPro>().text = "Back";

                }
                //else if (quitting == true && options == false)
                //{
                //
                //}
                //else if (quitting == false && options == true)
                //{
                //
                //}
            }
            


            controlRay.SetActive(false);
        }
        if (left.GetStateUp(SteamVR_Input_Sources.RightHand) && options == true)
        {
            transform.localScale = transform.localScale - new Vector3(0, 0.05f, 0);
        } else if (right.GetStateUp(SteamVR_Input_Sources.RightHand) && options == true)
        {
            transform.localScale = transform.localScale + new Vector3(0, 0.05f, 0);
        }
    }

    private void ResetScreens()
    {
        OptionsS.GetComponentInChildren<TextMeshPro>().text = "Options";
        StartS.GetComponentInChildren<TextMeshPro>().text = "Start";
        QuitS.GetComponentInChildren<TextMeshPro>().text = "Quit";
    }

    private IEnumerator StartGame()
    {
        PlayerPrefs.SetFloat("Height", transform.localScale.y);
        SteamVR_Fade.View(Color.black, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        PlayerPrefs.SetInt("Index", 0);


        SceneManager.LoadScene(1);

    }
}

