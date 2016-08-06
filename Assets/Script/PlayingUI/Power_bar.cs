using UnityEngine;
using System.Collections;

public class Power_bar : MonoBehaviour {
    public UILabel power_bar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.power>900)
		{
			power_bar.text="POWER:|||||||||";
		}
		else if(Player.power>800)
		{
			power_bar.text="POWER:||||||||";
		}
		else if(Player.power>700)
		{
			power_bar.text="POWER:|||||||";
		}
		else if(Player.power>600)
		{
			power_bar.text="POWER:||||||";
		}
		else if(Player.power>500)
		{
			power_bar.text="POWER:|||||";
		}
		else if(Player.power>400)
		{
			power_bar.text="POWER:||||";
		}
		else if(Player.power>300)
		{
			power_bar.text="POWER:|||";
		}
		else if(Player.power>200)
		{
			power_bar.text="POWER:||";
		}
		else if(Player.power>100)
		{
			power_bar.text="POWER:|";
		}
		else
		{
			power_bar.text="POWER:";
		}
	
	}
}
