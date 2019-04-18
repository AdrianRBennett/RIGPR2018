using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSon_Faces : MonoBehaviour {

    private GameObject ErrorMsg;

    public GameObject WatsonObj;

	public Material defaultFace;

    public Material helloFace;

	public Material[] randomFaces = new Material[8];

    public Material[] confusedFaces = new Material[2];

    public Material[] errorFaces = new Material[2];

	public Material[] loadingFaces = new Material[4];
	
	private Renderer rend;
	
	
    private bool confused = false;
    private bool pInput = false;
    

	private void Start(){
        ErrorMsg = GameObject.Find("Error Message");
        ErrorMsg.SetActive(false);
        WatsonObj = GameObject.Find("Watson_Obj");
		rend = GetComponent<Renderer>();
        //loading = true;
		StartCoroutine("Begin");
	}
	
	

    public void ResetWatson()
    {
        ErrorMsg.SetActive(false);
        WatsonObj = GameObject.Find("Watson_Obj");
        StartCoroutine("Loading");
    }
	
    IEnumerator Loading()
    {
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < loadingFaces.Length; i++)
            {
                rend.material = loadingFaces[i];
                yield return new WaitForSeconds(0.5f);
            }
        }

        if(WatsonObj != null)
        {
            
            if (WatsonObj.GetComponent<ExampleStreaming>().Active)
            {
                StartCoroutine("Begin");
            } else
            {
                StartCoroutine("Error");
            }
        } else
        {
            WatsonObj = GameObject.Find("Watson_Obj");

            StartCoroutine("Loading");
        }

    }

   
    IEnumerator Begin()
    {
        rend.material = helloFace;
        yield return new WaitForSeconds(2.5f);

        rend.material = randomFaces[5];
        yield return new WaitForSeconds(0.5f);
        rend.material = defaultFace;

        StartCoroutine("RandomF");
    }


    IEnumerator Error()
    {
        if (WatsonObj != null)
        {
            ErrorMsg.SetActive(true);

            while (!WatsonObj.GetComponent<ExampleStreaming>().Active)
            {
                rend.material = errorFaces[0];
                yield return new WaitForSeconds(2.0f);

                rend.material = errorFaces[1];
                yield return new WaitForSeconds(2.0f);

            }
        }
        ErrorMsg.SetActive(false);
        StartCoroutine("Loading");
    }

    IEnumerator RandomF()
    {
        if (WatsonObj != null)
        {
            while (WatsonObj.GetComponent<ExampleStreaming>().Active)
            {
                yield return new WaitForSeconds(Random.Range(5, 10));
                if (WatsonObj.GetComponent<ExampleStreaming>().Active == false) break;
                rend.material = randomFaces[Random.Range(0, 7)];
                yield return new WaitForSeconds(2.0f);
                if (WatsonObj.GetComponent<ExampleStreaming>().Active == false) break;
                rend.material = defaultFace;
            }
        }
        StartCoroutine("Loading");

        //StartCoroutine("RandomF");

    }

    IEnumerator ProcessInput()
    {
        pInput = true;
        int i = 0;
        while(pInput == true)
        {
            rend.material = loadingFaces[i];
            if (i < 3)
            {
                i += 1;
            }
            else
            {
                i = 0;
            }
            yield return new WaitForSeconds(0.5f);
        }

        if(confused == true)
        {
            rend.material = confusedFaces[0];
            yield return new WaitForSeconds(2.0f);

            rend.material = confusedFaces[1];
            yield return new WaitForSeconds(2.0f);
        }
        rend.material = defaultFace;

        StartCoroutine("RandomF");
    }
}