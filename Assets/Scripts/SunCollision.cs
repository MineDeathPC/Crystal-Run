using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCollision : MonoBehaviour
{
   void OnTriggerEnter(Collider collider)
	{
	 if(collider.gameObject.name == "player"){
	  DeathSystem.health = 0.0f;
	  Debug.Log("Death: Sun Collision");
	 }
	}
}
