using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class GameManager: MonoBehaviour {
	const int TOPLIST_LENGTH=5;
	public static GameManager Instance;
    public static int[] top_score=new int []{0,0,0,0,0,0,0,0,0,0};//静态数组用于存储最高分
	public int score;
	private int refreshed;
	private GameObject pause_menu;
	private GameObject playing_plane;
	private GameObject game_over_plane;
	public int pause_sign;
	public AudioSource bibi;

	void Awake()
	{
		Instance=this;
	}
	// Use this for initialization
	void Start () {
		WapsUnitySDK.removeBannerAdAction();
		ballAction.hit_player=0;
		Time.timeScale=1;
		refreshed=0;
		StartCoroutine(FindAndSet(1000));
	}
	// Update is called once per frame
	void Update () {
		
		if(ballAction.hit_player==0)
		{
			refreshed=0;
			if(pause_sign==1)
		    {
			    Time.timeScale=0;
			    pause_menu.SetActiveRecursively(true);
			    playing_plane.SetActiveRecursively(false);
		    }
		    else
		    {
		    	Time.timeScale=1;
			    pause_menu.SetActiveRecursively(false);
			    playing_plane.SetActiveRecursively(true);
		  	
		    }
			game_over_plane.SetActiveRecursively(false);
		}
		else
		{
			if(refreshed==0)
			{
			  refreshed=1;
	          if(OptionManager.SoundState==true)
		         bibi.Play();
			  refresh_topscore();
			  Fwrite_topscore();
			}
			pause_menu.SetActiveRecursively(false);
		    //playing_plane.SetActiveRecursively(false);
			game_over_plane.SetActiveRecursively(true);
			Time.timeScale=0;
			
		}
		
		
		
	
	}
	
    IEnumerator FindAndSet(int waittime)
	{
		if(fileExist(Application.persistentDataPath,"TopList.txt"))
		{	
	        LoadTopList(Application.persistentDataPath,"TopList.txt");
		}
		else
		{
			Fwrite_topscore();
		}
        pause_menu=GameObject.Find("PauseMenu");
        playing_plane=GameObject.Find("Playingplane");
	    game_over_plane=GameObject.Find("GameOverplane");
		pause_sign=0;
	

		pause_menu.SetActiveRecursively(false);
		playing_plane.SetActiveRecursively(true);
		game_over_plane.SetActiveRecursively(false);
		yield return waittime;
    }
	void LoadTopList(string path,string name)
	{
		StreamReader sr=null;
		sr=File.OpenText(path+"//"+name);
	    int i,x;
		for(i=0;i<TOPLIST_LENGTH;i++)
		{
			x=Convert.ToInt32(sr.ReadLine());
			if(x!=-1)
			{
				top_score[i]=x;
			}
		}
		sr.Close();
		sr.Dispose();
	}
	void CreateFile(string path,string name)
	{
		StreamWriter sw;
		FileInfo t=new FileInfo(path+"//"+name);
		sw=t.CreateText();
		sw.Close ();
		sw.Dispose();
	}
	void WriteFile(string path,string name,string info)
	{
		StreamWriter sw;
		FileInfo t=new FileInfo(path+"//"+name);
		sw=t.AppendText();
		sw.WriteLine(info);
		sw.Close();
		sw.Dispose();
	}
	void Fwrite_topscore()
	{
		int i;
		CreateFile(Application.persistentDataPath,"TopList.txt");
		
		for(i=0;i<TOPLIST_LENGTH;i++)
		{
		    WriteFile(Application.persistentDataPath,"TopList.txt",top_score[i]+"");
		}
	}
	void refresh_topscore()
	{
		int i,j;
		for(i=0;i<TOPLIST_LENGTH;i++)
		{
			if(top_score[i]<score)
			{
				for(j=TOPLIST_LENGTH-1;j>i;j--)
				{
					top_score[j]=top_score[j-1];
				}
				top_score[i]=score;
				break;
			}
			
		}
	}
	bool fileExist(string path,string name)
	{
	   StreamWriter sw; 
       FileInfo t = new FileInfo(path+"//"+ name); 

       if(!t.Exists) 
	   {  
			return false;
       } 
	   else
		{
			return true;
		}


	}
	
	
}

