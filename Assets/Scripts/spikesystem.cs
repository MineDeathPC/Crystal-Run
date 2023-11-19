using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesystem : MonoBehaviour
{
   
   
        public GameObject spike;
		public Renderer spikeRender;
		public AudioSource spikeAudio;
   
    
 
   void Start()
   {
	spikeRender.enabled = false;
   }
	
	void OnTriggerEnter(Collider collider){
	 if(collider.gameObject.name == "player"){
	  spikeRender.enabled = true;
	  spike.transform.localScale = new Vector3(2,5,2);
	  spikeAudio.Play();
	  Destroy(gameObject.transform.parent.gameObject,5);
	 }
	}
	
	
}

