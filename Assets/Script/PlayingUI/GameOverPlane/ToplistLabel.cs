using UnityEngine;
using System.Collections;

public class ToplistLabel : MonoBehaviour {
	public UILabel Tlabel;
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		Tlabel.text="*TOP SCORE*\n"+GameManager.top_score[0]+"\n"+GameManager.top_score[1]+
			"\n"+GameManager.top_score[2]+"\n"+GameManager.top_score[3]+"\n"+GameManager.top_score[4]+"\n";
	
	}
}
