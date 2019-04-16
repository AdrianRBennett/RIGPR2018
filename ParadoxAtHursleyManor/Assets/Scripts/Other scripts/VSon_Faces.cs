using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSon_Faces : MonoBehaviour {

    public GameObject WatsonObj;

	public Material defaultFace;

    public Material helloFace;

	public Material[] randomFaces = new Material[8];

    public Material[] confusedFaces = new Material[2];

    public Material[] errorFaces = new Material[2];

	public Material[] loadingFaces = new Material[3];
	
	private Renderer rend;
	
	public bool loading = false;
    public bool error = false;
    public bool confused = false;


	private void Awake(){
        WatsonObj = GameObject.Find("Watson_Obj");
		rend = GetComponent<Renderer>();
        loading = true;
		//StartCoroutine("Begin");
	}
	
	private void Update(){
		//if(Input.GetKeyDown(KeyCode.F)){
		//		loading = false;
		//		rend.material = defaultFace;
		//		StopCoroutine("LoadingF");
		//		
		//}
		//if(!loading){
		//	rend.material = defaultFace;
		//}

        if(WatsonObj == null)
        {
            WatsonObj = GameObject.Find("Watson_Obj");
        } else
        {
            if(WatsonObj.GetComponent<ExampleStreaming>()._service.IsListening == true && error)
            {
                StopAllCoroutines();
                rend.material = defaultFace;
                error = false;
            } else if(WatsonObj.GetComponent<ExampleStreaming>()._service.IsListening == false && !error)
            {
                error = true;
                StartCoroutine("LoadingF");
            }
        }
	}
	
    IEnumerator Begin()
    {
        rend.material = helloFace;
        yield return new WaitForSeconds(2.5f);

        rend.material = defaultFace;
        yield return new WaitForSeconds(2.5f);

        if(confused || error)
        {
            StartCoroutine("LoadingF");
        } else
        {
            StartCoroutine("RandomF");
        }
    }

	IEnumerator LoadingF(){
		if(!loading){
			yield return null;
		} else {
            for(int j = 0; j < 3; j++)
            {
			    for(int i = 0; i < loadingFaces.Length; i++){
			    	rend.material = loadingFaces[i];
			    	yield return new WaitForSeconds(0.25f);
			    }	
            }
		}

        if (confused)
        {
            StartCoroutine("Confused");
        } else if (error)
        {
            StartCoroutine("Error");
        }
		
	}
	
	IEnumerator Confused()
    {
        for (int i = 0; i < 3; i++)
        {
            rend.material = confusedFaces[0];
            yield return new WaitForSeconds(0.5f);

            rend.material = confusedFaces[1];
            yield return new WaitForSeconds(0.5f);
        }

        StartCoroutine("LoadingF");
    }

    IEnumerator Error()
    {
        for (int i = 0; i < 3; i++)
        {
            rend.material = errorFaces[0];
            yield return new WaitForSeconds(0.5f);

            rend.material = errorFaces[1];
            yield return new WaitForSeconds(0.5f);
        }


        StartCoroutine("LoadingF");
    }

    IEnumerator RandomF()
    {
        rend.material = randomFaces[Random.Range(0, 7)];
        yield return new WaitForSeconds(2);
        StartCoroutine("RandomF");

    }
    
}