using UnityEngine;
using System.Collections;

public class Pause_button : MonoBehaviour {
	private GameObject pause_menu;
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
			GameManager.Instance.pause_sign=1;
	}
    void OnClick()
	{
		
		
		GameManager.Instance.pause_sign=1;
	}
		
}
