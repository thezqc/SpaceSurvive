using UnityEngine;
using System.Collections;

public class theHead : MonoBehaviour {
	public float waittime;
	float timer;
	// Use this for initialization
	void Start () {
		timer=0;
	    while(timer<waittime)
		{
			timer+=Time.deltaTime;
		}
		Application.LoadLevel("Title_sence");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
