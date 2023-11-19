using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
	public AudioSource PickUpSound;
	public ParticleSystem PickupParticle;
	
	public int GainIfYellow = 1;
	public int GainIfRed = 1;
	public int GainIfGreen = 1;
	public int GainIfBlue = 1;
	public int GainIfWhite = 1;
	
	
	
	
   void OnTriggerEnter(Collider collider)
   {
	 if(collider.gameObject.name == "player"){
	 Debug.Log("Coin pickup");
	 PickUpSound.Play();
	 PickupParticle.Play();
	 GainPoint();
	 Destroy(gameObject, 0.3f);
	 }  
   }
   
   
   
   void GainPoint()
   {
	   if(gameObject.transform.Find("Point (1)").GetComponent<Light>().color == Color.yellow){
		   PointSystem.TotalPoints = PointSystem.TotalPoints + GainIfYellow;
		   Debug.Log("Points: " + PointSystem.TotalPoints + " , Gained Color : " + gameObject.transform.Find("Point (1)").GetComponent<Light>().color);
	   }
	   else if(gameObject.transform.Find("Point (1)").GetComponent<Light>().color == Color.red){
		   PointSystem.TotalPoints = PointSystem.TotalPoints + GainIfRed;
		   Debug.Log("Points: " + PointSystem.TotalPoints + " , Gained Color : " + gameObject.transform.Find("Point (1)").GetComponent<Light>().color);
	   }
	   else if(gameObject.transform.Find("Point (1)").GetComponent<Light>().color == Color.green){
		    PointSystem.TotalPoints = PointSystem.TotalPoints + GainIfGreen;
			Debug.Log("Points: " + PointSystem.TotalPoints + " , Gained Color : " + gameObject.transform.Find("Point (1)").GetComponent<Light>().color);
	   }
	   else if(gameObject.transform.Find("Point (1)").GetComponent<Light>().color == Color.blue){
		    PointSystem.TotalPoints = PointSystem.TotalPoints + GainIfBlue;
			Debug.Log("Points: " + PointSystem.TotalPoints + " , Gained Color : " + gameObject.transform.Find("Point (1)").GetComponent<Light>().color);
	   }
	   else if(gameObject.transform.Find("Point (1)").GetComponent<Light>().color == Color.white){
		    PointSystem.TotalPoints = PointSystem.TotalPoints + GainIfWhite;
			Debug.Log("Points: " + PointSystem.TotalPoints + " , Gained Color : " + gameObject.transform.Find("Point (1)").GetComponent<Light>().color);
	   }
	   
   }
   
   
   
}
