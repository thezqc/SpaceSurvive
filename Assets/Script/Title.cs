using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class Title : MonoBehaviour {
	// Use this for initialization
	public static int topscore;
	
	bool Ad_over;
	void Start () {
		Ad_over=false;
		if(!fileExist(Application.persistentDataPath,"TopList.txt"))
		{
			CreateFile(Application.persistentDataPath,"TopList.txt");
		    for(int i=0;i<5;i++)
		    {
			    WriteFile (Application.persistentDataPath,"TopList.txt","0");
		    }
		}
		LoadTopScore(Application.persistentDataPath,"TopList.txt");
		
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		
		if(Ad_over==false&&WapsUnitySDK.getConfigOnLine()=="true")
		{
			Ad_over=true;
			WapsUnitySDK.popAdShowAction();
		    WapsUnitySDK.bannerAdShowAction();
		}

	}
	void OnGUI()
	{
		
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
	void LoadTopScore(string path,string name)
	{
		StreamReader sr=null;
		sr=File.OpenText(path+"//"+name);
		topscore=Convert.ToInt32(sr.ReadLine());
		sr.Close();
		sr.Dispose();
	}
	
}
