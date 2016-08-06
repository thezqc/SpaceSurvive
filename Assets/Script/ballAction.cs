using UnityEngine;
using System.Collections;

public class ballAction : MonoBehaviour {
	private float ball_speed;
	public float ball_speed_coe=0.001f;
	//public float life_time=1;
	private float kill_range;
	private float ball_x_limit;
	private float ball_z_limit;
	public static int hit_player=0;
	protected Transform t_player;
	protected Transform m_transform;
	private float ballSize;
	private float ball_scalecoe;
	private int in_field=2;
	public float ball_div_player_coe=11.0f/20.0f;
	Vector3 direction=new Vector3();
	// Use this for initialization
	void Start () {
		ball_speed=979.6509f*ball_speed_coe;
		ballSize=Player.xSize*ball_div_player_coe;
		ball_scalecoe=ballSize/this.GetComponent<MeshFilter>().mesh.bounds.size.x;
		this.transform.localScale=new Vector3(ball_scalecoe,ball_scalecoe,ball_scalecoe);
		GameObject obj=GameObject.Find("playerplane");
		if(obj!=null)
		{
	       t_player=obj.transform;
		}
		m_transform=this.transform;
		kill_range=(Player.xSize+ballSize)/2;
		Vector3 leftdown=new Vector3();
		Vector3 rightup=new Vector3();
		
		leftdown.x=Camera.main.ViewportToWorldPoint(new Vector3(0,0,5)).x;
		leftdown.z=Camera.main.ViewportToWorldPoint(new Vector3(0,0,5)).z;
		rightup.x=Camera.main.ViewportToWorldPoint(new Vector3(1,1,5)).x;
		rightup.z=Camera.main.ViewportToWorldPoint(new Vector3(1,1,5)).z;
		ball_x_limit=(rightup.x-leftdown.x)/2.0f;
		ball_z_limit=(rightup.z-leftdown.z)/2.0f;
		direction.z=Mathf.Cos(this.m_transform.eulerAngles.y*Mathf.Deg2Rad);
		direction.x=Mathf.Sin(this.m_transform.eulerAngles.y*Mathf.Deg2Rad);
		direction.y=0;
		//Debug.Log("this.m_transform.eulerAngles.y:"+this.m_transform.eulerAngles.y);
		//Debug.Log("direction.z:"+direction.z);
		//Debug.Log("direction.x:"+direction.x);
		this.m_transform.eulerAngles=new Vector3(0,0,0);
		
	}
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(m_transform.position.x)-ballSize/2.0f>Mathf.Abs(ball_x_limit)||Mathf.Abs(m_transform.position.z)-ballSize/2.0f>Mathf.Abs(ball_z_limit))
		{
			if(in_field==1)
			{
			   Destroy(this.gameObject);
			   GameManager.Instance.score+=1;
			}
		}
		else
		{
			if(in_field==2)
				in_field=1;
		}
		if(Mathf.Pow(Mathf.Pow(t_player.position.x-m_transform.position.x,2)+Mathf.Pow(t_player.position.z-m_transform.position.z,2),0.5f)<kill_range)
		{
			hit_player=1;
			Destroy(this.gameObject);
		}
		this.m_transform.Translate(direction*ball_speed*Time.deltaTime,Space.World);
	    
	}
	
}

