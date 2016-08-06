using UnityEngine;
using System.Collections;

public class Sondbutton : MonoBehaviour {
    public UILabel label;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(OptionManager.SoundState==true)
		{
			label.text="ON";
		}
	    else
		{
			label.text="OFF";
		}
		
	}
	void OnClick()
	{
		OptionManager.SoundState=(!OptionManager.SoundState);
		
	}
}
