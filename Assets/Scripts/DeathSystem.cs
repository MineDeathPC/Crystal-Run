using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class DeathSystem : MonoBehaviour
{
   
     public GameObject PlayerObject;
	 public GameObject PlayerControls;
	 public GameObject DeathUI;
	 public Rigidbody PlayerRigidbody;
	 public int DeathFreezeDelay = 5;
	 public PostProcessVolume DeathPostProcessor;
	 public int FallLimit; //-31
	 [HideInInspector]
	 bool dead = false;
	 
	 public bool candie = true;
	 
	 
	 
	 public static float health = 100.0f;
   
   
    void Start()
    {
      DeathUI.SetActive(false);
    }

    // Update is called once per frame
	
	void DeathMain()
	{
		if(candie == true)
		{
		 if(PlayerObject.transform.position.y < FallLimit){
			Debug.Log("death");
			DeathPostProcessor.isGlobal = true;
			dead = true;
			if(dead == true){
				StartCoroutine(ProceedDeath());
				dead = false;
			}
			
			
	}
	
	if(health < 1){
			dead = true;
			Debug.Log("death");
			DeathPostProcessor.isGlobal = true;
			if(dead == true){
				StartCoroutine(ProceedDeath());
				dead = false;
			}
			}
			
	}
	IEnumerator ProceedDeath()
	{
			yield return new WaitForSeconds(DeathFreezeDelay);
			Debug.Log("death delay end");
			PlayerRigidbody.constraints = RigidbodyConstraints.FreezePosition;
			PlayerControls.SetActive(false);
			DeathUI.SetActive(true);
		
	}		
	}
	
	
	
	
    void Update()
    {
		if(dead == false)
		{
        DeathMain();
		}
		
    }
}
