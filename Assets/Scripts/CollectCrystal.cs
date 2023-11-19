using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCrystal : MonoBehaviour
{
	public LayerMask whatIsCrystal;
	public GameObject PurpleCrystal;
	public GameObject BlueCrystal;
	public GameObject GreenCrystal;
	public float MaxHitDistance = 10.0f;
	public int totalGreen;
	public int totalBlue;
	public int totalPurple;
	
	
	
	
	
	
	
	void Start()
	{
	totalGreen = PlayerPrefs.GetInt("totalgreencrystal");
	 totalPurple = PlayerPrefs.GetInt("totalpurplecrystal");
	totalBlue = PlayerPrefs.GetInt("totalbluecrystal");
	}
	
	
	
	/*
	void ShootRayMobile(){
		 RaycastHit hit;
		 RaycastHit pcHit;
	 for(int i=0;i<Input.touchCount;i++){
     Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
	
	 
	  if(Physics.Raycast(ray, out hit,MaxHitDistance, whatIsCrystal)){
	   	Debug.Log("ray");
		
	   if(hit.collider.gameObject.name.Contains("purpleCrystal")){
		Debug.Log("hit purple crystal!");
		totalPurple = totalPurple + 1;
		Destroy(hit.collider.gameObject.GetComponent<MeshRenderer>());
		hit.collider.gameObject.transform.Find("DestroyParticle").GetComponent<ParticleSystem>().Play();
		Destroy(hit.collider.gameObject,600);
	   }
	   else if(hit.collider.gameObject.name.Contains("blueCrystal")){
		Debug.Log("hit blue crystal!");
		totalBlue = totalBlue + 1;
		Destroy(hit.collider.gameObject.GetComponent<MeshRenderer>());
		hit.collider.gameObject.transform.Find("DestroyParticle").GetComponent<ParticleSystem>().Play();
		Destroy(hit.collider.gameObject,600);
	   }
	   else if(hit.collider.gameObject.name.Contains("GreenCrystal")){
		Debug.Log("hit green crystal!");
		totalGreen = totalGreen + 1;
		Destroy(hit.collider.gameObject.GetComponent<MeshRenderer>());
		hit.collider.gameObject.transform.Find("DestroyParticle").GetComponent<ParticleSystem>().Play();
		Destroy(hit.collider.gameObject,600);
	   }
	  }
	  
	 }
	 
	 
	 
	 
	 
	  }*/
	 
	 
	 
	
	
	
	
	
	
	void OnCollisionEnter(Collision collision)
	{
    if(collision.gameObject.name.Contains("purpleCrystal")){
	Debug.Log("hit purple crystal!");
		/*totalPurple = totalPurple + 1;
		Destroy(collision.gameObject.GetComponent<MeshRenderer>());
		Destroy(collision.gameObject.GetComponent<BoxCollider>());
		collision.gameObject.transform.Find("DestroyParticle").GetComponent<ParticleSystem>().Play();
		collision.gameObject.GetComponent<SphereCollider>().enabled = false;
		Destroy(collision.gameObject,600);	
		PlayerPrefs.SetInt("totalpurplecrystal",totalPurple);*/
	}
	else if(collision.gameObject.name.Contains("blueCrystal")){
	Debug.Log("hit blue crystal!");
		totalBlue = totalBlue + 1;
		Destroy(collision.gameObject.GetComponent<MeshRenderer>());
		Destroy(collision.gameObject.GetComponent<SphereCollider>());
		Destroy(collision.transform.Find("Emission").gameObject);
		collision.gameObject.transform.Find("DestroyParticle").GetComponent<ParticleSystem>().Play();
		//collision.gameObject.GetComponent<SphereCollider>().enabled = false;
		Destroy(collision.gameObject,600);	
		PlayerPrefs.SetInt("totalbluecrystal",totalBlue);
	}
	else if(collision.gameObject.name.Contains("GreenCrystal")){
		Debug.Log("hit blue crystal!");
		totalBlue = totalBlue + 1;
		Destroy(collision.gameObject.GetComponent<MeshRenderer>());
		Destroy(collision.gameObject.GetComponent<SphereCollider>());
		Destroy(collision.transform.Find("Emission").gameObject);
		collision.gameObject.transform.Find("DestroyParticle").GetComponent<ParticleSystem>().Play();
	//	collision.gameObject.GetComponent<SphereCollider>().enabled = false;
		Destroy(collision.gameObject,600);	
		PlayerPrefs.SetInt("totalgreencrystal",totalGreen);
	}
	}

	
	
	void Update()
	{
	/*	if(Input.touchCount > 0){
			ShootRayMobile();
		}
		
		if(Input.GetMouseButtonDown(0)){
			PCShootRay();
		}*/
	}
	
	
	
	
}
