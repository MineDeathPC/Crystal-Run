using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HoverPlatformMain : MonoBehaviour
{
    public string platID;   
	[HideInInspector]
	public bool proceed = false;
	public GameObject platEND;
	public float multiplicationFactor = 0.1f;
	public AudioSource plataudio;
	[HideInInspector]
	public bool isSet = false;
	
	
	
	
	int cooldown = 0;
	public NavMeshAgent agent;
	
    void Start()
    {
	 if(GameObject.Find("player") != null){
	  proceed = true;
	  StartCoroutine(OnAgent());
	 }
	 plataudio.Play();
    }

   
    void Update()
    {
        
    }
	
	IEnumerator OnAgent()
	{
		yield return new WaitForSeconds(1);
		agent.enabled = true;
	}
	
	void OnTriggerEnter(Collider collider){
	 if(proceed == true && isSet == false){
	 if(collider.gameObject.name == "player"){
		 if(cooldown == 0){
	 Debug.Log("standing on hover plat");
	/* Vector3 direction = gameObject.transform.position - platEND.transform.position;
	 Vector3 newVector = -direction * multiplicationFactor;
	 gameObject.GetComponent<Rigidbody>().velocity = newVector;*/
	 agent.SetDestination(platEND.transform.position);
	// collider.gameObject.transform.parent = gameObject.transform;
	 //isSet = true;
		 }
	 }
	 }
	 
	}
	
	
	
	
	
	
}
