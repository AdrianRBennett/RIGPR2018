using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Vive_Input : MonoBehaviour {

    public GameObject cameraRig;

    public GameObject controlRay;

    public SteamVR_Action_Single squeezeAction;

    public SteamVR_Action_Boolean teleport;

    public Transform rightHand;

    private RaycastHit rayHit;

    private bool isTeleporting = false;
    public float fadeTime = 2f;

    private void Start()
    {
        controlRay.SetActive(false);
    }

    void Update () {
        //if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.RightHand))
        //{
        //    Debug.Log("Teleport!");
        //}
        float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);
        if(triggerValue > 0.0f)
        {
            controlRay.SetActive(true);
            //Debug.DrawLine(rightHand.position, (rightHand.position + rightHand.forward * 10.0f), Color.blue);
            if(Physics.Raycast(rightHand.position, rightHand.forward,out rayHit))
            {
                controlRay.transform.position = rightHand.position + ((rayHit.point - rightHand.position) * 0.5f);
                controlRay.transform.LookAt(rayHit.point);
                controlRay.transform.Rotate(Vector3.right, 90.0f);
                controlRay.transform.localScale = new Vector3(controlRay.transform.localScale.x, rayHit.distance * 0.5f, controlRay.transform.localScale.z);

                RayOutput();
            }
            else
            {
                controlRay.transform.position = rightHand.position + (rightHand.forward * 100.0f);
                controlRay.transform.rotation = rightHand.rotation;
                controlRay.transform.Rotate(Vector3.right, 90.0f);
                controlRay.transform.localScale = new Vector3(controlRay.transform.localScale.x, 100.0f, controlRay.transform.localScale.z);
            }
        } else
        {
            controlRay.SetActive(false);
        }
	}

    private void RayOutput()
    {
        if (rayHit.collider.tag == "Telepad" && teleport.GetStateDown(SteamVR_Input_Sources.RightHand) && isTeleporting == false)
        {
            StartCoroutine("TeleportRig", rayHit.collider.gameObject.transform.position);
        }else if(rayHit.collider.tag == "Mirror")
        {
            if (SteamVR_Input._default.inActions.RotateLeft.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                rayHit.collider.gameObject.GetComponent<Mirror_Rotate>().RotateLeft();
            } else if (SteamVR_Input._default.inActions.RotateRight.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                rayHit.collider.gameObject.GetComponent<Mirror_Rotate>().RotateRight();
            }
        }
    }

    private IEnumerator TeleportRig(Vector3 position)
    {
        isTeleporting = true;

        SteamVR_Fade.View(Color.black, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        cameraRig.transform.position = position;

        SteamVR_Fade.View(Color.clear, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        isTeleporting = false;

    }
}
