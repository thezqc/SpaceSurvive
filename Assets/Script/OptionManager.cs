using UnityEngine;
using System.Collections;

public class OptionManager : MonoBehaviour {
	public static bool SoundState;
	// Use this for initialization

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		WapsUnitySDK.init();
	
		
	}
	void Start () {
	     SoundState=true;
	     
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
