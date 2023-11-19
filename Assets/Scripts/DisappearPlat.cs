using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlat : MonoBehaviour
{
   
   public GameObject trigger;
   public AudioSource audio;
   public ParticleSystem particleSystem;
   public GameObject tokill;
   public int dissapearTime = 1;
   bool collided = false;
   
    void Start()
    {
        
    }
	
	void OnTriggerEnter(Collider collision){
	 if(collision.gameObject.name == "player"){
		 	Debug.Log("attemptkilla");
		 if(collided == false){
		 StartCoroutine(killplat());
		 collided = true;
		 }
	 }
	}
	
	IEnumerator killplat()
	{
	Debug.Log("attemptkill");
	 yield return new WaitForSeconds(dissapearTime);
	  audio.Play();
	  particleSystem.Play();
	 Destroy(tokill,1);
	}

}
