using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float player_size_coe=0.125f;
	public float player_speed_coe=0.02f;
	public static float power;
	private float player_speed;
	private float scalecoe;
	public static float xSize;//xSize是player的直径
	private float xWidth;
	private float zHeight;
	private float x_limit;
	private float z_limit;
	private float movev;
	private float moveh;
	private float minlen;
	private float lowpower_coe;
	public float power_increase=5;
	public float power_decrease_coe=50;
	protected Transform m_transform;
	// Use this for initialization
	void Start () {
		player_speed=979.6509f*player_speed_coe;
		m_transform=this.transform;
		Vector3 leftdown=new Vector3();
		Vector3 rightup=new Vector3();
		leftdown.x=Camera.main.ViewportToWorldPoint(new Vector3(0,0,5)).x;
		leftdown.z=Camera.main.ViewportToWorldPoint(new Vector3(0,0,5)).z;
		rightup.x=Camera.main.ViewportToWorldPoint(new Vector3(1,1,5)).x;
		rightup.z=Camera.main.ViewportToWorldPoint(new Vector3(1,1,5)).z;
		xWidth=rightup.x-leftdown.x;
		zHeight=rightup.z-leftdown.z;
	    minlen=(xWidth<zHeight)?xWidth:zHeight;
		scalecoe=minlen*player_size_coe/this.GetComponent<MeshFilter>().mesh.bounds.size.x;
		m_transform.localScale=new Vector3(scalecoe,scalecoe,scalecoe);
		xSize=minlen*player_size_coe;
		x_limit=xWidth/2-xSize/2;
		z_limit=zHeight/2-xSize/2;
		power=1000;

	}
	
	// Update is called once per frame
	void Update () {
		if(power>0)
		{
		   keyboard_control();
		   gravity_contral();
		}
		if(power<80&&power>=50)
		{
			lowpower_coe=0.6f;
		}
		else if(power<50&&power>=30)
		{
			lowpower_coe=0.4f;
		}
		else if(power<30&&power>=20)
		{
			lowpower_coe=0.3f;
		}
		else if(power<20&&power>=12)
		{
			lowpower_coe=0.2f;
		}
		else if(power<12&&power>=5)
		{
			lowpower_coe=0.09f;
		}
		else if(power<5&&power>=0)
		{
			lowpower_coe=1314f;
		}
		else
		{
			lowpower_coe=1;
		}
		if(this.m_transform.position.x>x_limit)
		{
			this.m_transform.position=new Vector3(x_limit,this.m_transform.position.y,m_transform.position.z);
		}
		if(this.m_transform.position.x<-x_limit)
		{
			this.m_transform.position=new Vector3(-x_limit,this.m_transform.position.y,m_transform.position.z);
		}
		if(this.m_transform.position.z>z_limit)
		{
			this.m_transform.position=new Vector3(this.m_transform.position.x,this.m_transform.position.y,z_limit);
		}
		if(this.m_transform.position.z<-z_limit)
		{
			this.m_transform.position=new Vector3(this.m_transform.position.x,this.m_transform.position.y,-z_limit);
		}
		power+=power_increase;
		if(power>1000)
			power=1000;
	}
	void power_consume(float x,float y)
	{
		power-=Mathf.Pow(x*x+y*y,0.5f)*power_decrease_coe;
	}
	void keyboard_control()
	{
		movev=0;
		moveh=0;
		if(Input.GetKey (KeyCode.UpArrow))
		{
			movev+=player_speed*Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			movev-=player_speed*Time.deltaTime;
		}	
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			moveh-=player_speed*Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			moveh+=player_speed*Time.deltaTime;
		}
		this.m_transform.Translate(new Vector3(moveh,0,movev));
		power_consume(moveh,movev);
	}
	void gravity_contral()
	{
		movev=0;
		moveh=0;
		if(lowpower_coe!=1314f)
		{
			moveh+=Input.acceleration.x>=0?Mathf.Pow(Input.acceleration.x*6,1.3f)*player_speed*lowpower_coe*Time.deltaTime:(-Mathf.Pow(Mathf.Abs(Input.acceleration.x)*6,1.3f)*player_speed*lowpower_coe*Time.deltaTime);
			movev+=Input.acceleration.y>=0?Mathf.Pow(Input.acceleration.y*6,1.3f)*player_speed*lowpower_coe*Time.deltaTime:(-Mathf.Pow(Mathf.Abs(Input.acceleration.y)*6,1.3f)*player_speed*lowpower_coe*Time.deltaTime);
		}
		else
		{
			moveh+=Input.acceleration.x>=0?0.872f*player_speed*0.01f*Time.deltaTime:(-0.872f*player_speed*0.01f*Time.deltaTime);
			movev+=Input.acceleration.y>=0?0.872f*player_speed*0.01f*Time.deltaTime:(-0.872f*player_speed*0.01f*Time.deltaTime);
		
		}
		this.m_transform.Translate(new Vector3(moveh,0,movev));
		power_consume(moveh,movev);
	}
}
