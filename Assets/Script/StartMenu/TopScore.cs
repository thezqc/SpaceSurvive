using UnityEngine;
using System.Collections;

public class TopScore : MonoBehaviour {

	public UILabel label;
	void Update () {
		label.text="TOPSCORE:"+Title.topscore;
	
	}
}
