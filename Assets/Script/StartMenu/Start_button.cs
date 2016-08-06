using UnityEngine;
using System.Collections;

public class Start_button : MonoBehaviour {

    void Start()
	{
		
	}
	void OnClick ()  
    {  
	   //yield return 100;
      StartCoroutine(Loadit(5000));
	   
	   
	}
	IEnumerator Loadit(int waittime)
	{
		
		
		Application.LoadLevel("sence");
		yield return waittime;
	}

}
