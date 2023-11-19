using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBlockPrevention : MonoBehaviour
{
    public GameObject blueCrystal;
    public GameObject purpleCrystal;
    public GameObject greenCrystal;
    int OldLayer;
	
	[HideInInspector]
	 Collider[] hitColliders;
	[HideInInspector]
	SpawnLevel groundSpawner;
	
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<SpawnLevel>();
   
    }
	
	
   void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(gameObject.transform.position, groundSpawner.OverlapSphereRadius);
 }
 
    void FixedUpdate()
	{
		  hitColliders = Physics.OverlapSphere(gameObject.transform.position, groundSpawner.OverlapSphereRadius);
		
		  for(int i=0;i<hitColliders.Length;i++){
			  if(hitColliders[i].gameObject == blueCrystal || hitColliders[i].gameObject == purpleCrystal || hitColliders[i].gameObject == greenCrystal){
				  
				  if(hitColliders[i].transform != gameObject.transform.parent){
			       Destroy(hitColliders[i].gameObject,groundSpawner.DestroyCollidedCrystalDelay);
				  }
			  }
		  }
		   
	}
}


