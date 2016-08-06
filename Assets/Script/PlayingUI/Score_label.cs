using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Score_label : MonoBehaviour {
	public UILabel label;
	// Use this for initialization
	void Start () {
		
	                      
	}
	
	// Update is called once per frame
	void Update () {
		label.text="SCORE: "+GameManager.Instance.score;
	
	}
}
