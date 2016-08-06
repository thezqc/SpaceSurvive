using UnityEngine;
using System.Collections;

public class MainMnueButton : MonoBehaviour {

	void OnClick ()  
    {  
        Application.LoadLevel("Title_sence");
	    Time.timeScale=1;
		ballAction.hit_player=0;
    }  
}
