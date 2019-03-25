using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScanBoard_Script : MonoBehaviour {

    public GameObject cameraObj;

    private TextMeshPro itemName;
    private TextMeshPro itemDesc;

    private Transform boardPos;

    private bool isDisplaying = false;

    // Use this for initialization
    void Start () {
        itemName = GameObject.Find("Item_Name").GetComponent<TextMeshPro>();
        itemDesc = GameObject.Find("Item_Desc").GetComponent<TextMeshPro>();
        transform.position = new Vector3(0.0f, -10.0f, 0.0f);
    }

    public void ChangeText(string newName, string newDesc, Transform itemPos)
    {
        if (!isDisplaying) {
            isDisplaying = true;
            itemName.SetText(newName);
            itemDesc.SetText(newDesc);

            boardPos = itemPos;

            StartCoroutine("Display");
        }
    }

    IEnumerator Display()
    {
        
        transform.position = Vector3.Lerp(transform.position, cameraObj.transform.position, 0.3f);
        transform.position = boardPos.position + (cameraObj.transform.right * 2);
        yield return new WaitForSeconds(5.0f);

        transform.position = new Vector3(0.0f, -10.0f, 0.0f);
        isDisplaying = false;
    }

	// Update is called once per frame
	void Update () {
        transform.LookAt(cameraObj.transform);
	}
}
