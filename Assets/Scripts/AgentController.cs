using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    // Start is called before the first frame update
	[HideInInspector]
	public GameObject Player;
	[HideInInspector]
	public Vector3 playerTransform;
	public NavMeshAgent agent;
	public int force;
	
	public AudioSource EnemyAudio;
	
	DeathSystem deathsystem;
	
	
	void Start()
	{
	deathsystem = GameObject.FindObjectOfType<DeathSystem>();
		EnemyAudio.Play();
     if(GameObject.Find("player") != null){
		Player = GameObject.Find("player");
	 }
	}
	
    
    

    // Update is called once per frame
    void Update()
    {
		if(GameObject.Find("player") != null){
      playerTransform = Player.transform.position;
	  agent.SetDestination(playerTransform);
		}
    }
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "player"){
		/*	Vector3 dir = collision.contacts[0].point - transform.position;
			 dir = -dir.normalized;
		     GetComponent<Rigidbody>().AddForce(dir*force);*/
			 Debug.Log("HIT");
			 if(DeathSystem.health > 0){
			 DeathSystem.health = DeathSystem.health - 1f;
			 }
		}
	}
}
