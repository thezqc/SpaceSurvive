using UnityEngine;
using System.Runtime.InteropServices;

public class WapsUnitySDK {
	
    static AndroidJavaClass mJc;
    static AndroidJavaObject mJo;
	
	
	
	public static void init()  
     {    
        if (Application.platform == RuntimePlatform.Android)   
        {  
			mJc=new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            mJo=mJc.GetStatic<AndroidJavaObject>("currentActivity");			
			mJo.Call("connectInit"); 
			mJo.Call("getPoints");
        }  
     }  
	
	
	
	
	 public static string getConfigOnLine()  
     {          
        if (Application.platform == RuntimePlatform.Android)   
        { 	
            string mConfigOnLine = mJo.Call<string>("getConfigOnLine");
			return mConfigOnLine;
        } 
		   
		    return "";
		
     } 
     
       
     public static void offersShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showOffers");  
        }  
     } 
	
	 public static void AppOffersShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showAppOffers");  
        }  
     } 
	
	public static void AppWallShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showAppWall");  
        }  
     } 
	
	public static void awardPointsAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("awardPoints",10);  
        }  
     }  
	
	public static void showMoreAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showMore");  
        }  
     } 
	
	public static void browserrShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showBrowser","http://www.baidu.com");  
        }  
     }  
	
	public static void miniAdShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showMiniAd");  
        }  
     } 
	
	public static void removeMiniAdAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("removeMiniAd");  
        }  
     } 
	
	public static void popAdShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showPopAd");  
        }  
     } 
	
	public static void gameOffersShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showGameOffers");  
        }  
     } 
	
	public static void adDetailShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showAdDetail");  
        }  
     } 
	
	public static void spendPointsAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("spendPoints",10);  
        }  
     } 
	
	public static void showMoreDetailAction(string app_id)  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showMore",app_id);  
        }  
     } 
	
	public static void feedbackShowAction()  
     {       
          if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showFeedback");  
		}
         
     } 
	
	public static void bannerAdShowAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showBannerAd");  
        }  
     } 
	
	public static void removeBannerAdAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("removeBannerAd");  
        }  
     } 
	
	
     public static void quitAdShowAdAction()  
     {       
        if (Application.platform == RuntimePlatform.Android)   
        {  
				mJo.Call("showQuitAd");  
        }  
     } 
	
	
	

}
