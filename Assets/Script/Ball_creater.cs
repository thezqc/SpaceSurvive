using UnityEngine;
using System.Collections;

public class Ball_creater : MonoBehaviour {

	public Transform m_ball;
	private float create_coe=758.618f;
	private Object obj;
	protected float m_timer=1.5f;
	protected Transform m_transform;
	protected Transform t_player;
	private int m_score;
	private float number;
	
	void Start () {
		GameObject obj=GameObject.Find("playerplane");
		if(obj!=null)
		{
	       t_player=obj.transform;
		}
		m_transform=this.transform;
		m_score=GameManager.Instance.score;
		
	}
	
	// Update is called once per frame
	void Update () {
		number=1.6419f*Mathf.Log(m_score+1.0f,(float)System.Math.E)+0.2388f;
		m_timer-=Time.deltaTime*create_coe*number/100f;
		if(m_timer<=0)
		{
			m_timer=Random.value*15f;
			if(m_timer<5)
			{
				m_timer=4f;
			    Vector3 relativePos=-m_transform.position+t_player.position;
				obj=Instantiate(m_ball,m_transform.position,Quaternion.LookRotation(relativePos));
			}
			
		}
	
	}
}
