using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class jumper : MonoBehaviour
{  


   void OnCollisionEnter(Collision collision)
   {
	   if(collision.gameObject.name == "player"){
		RigidbodyFirstPersonController.MovementSettings.isJumper = true;           
        Debug.Log("enter");		
	   }
   }
   void OnCollisionExit(Collision collision)
   {
	
		  
	   if(collision.gameObject.name == "player"){
		     IEnumerator go(){
				 yield return new WaitForSeconds(1);
		RigidbodyFirstPersonController.MovementSettings.isJumper = false;
	       Debug.Log("exit");	
			 }
			  StartCoroutine(go());	   
	   }
	  
   }
   
   
}
