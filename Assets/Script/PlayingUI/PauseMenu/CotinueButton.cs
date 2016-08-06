using UnityEngine;
using System.Collections;

public class CotinueButton : MonoBehaviour {
	
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
			GameManager.Instance.pause_sign=0;
	}
	void OnClick ()  
    {  
       GameManager.Instance.pause_sign=0;  
    }  
}
