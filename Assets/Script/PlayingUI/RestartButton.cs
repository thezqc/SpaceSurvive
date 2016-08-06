using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	void OnClick ()  
    {  
		 Application.LoadLevel(Application.loadedLevel);
		 GameManager.Instance.pause_sign=0;
		 ballAction.hit_player=0;
		
    }
	
}
