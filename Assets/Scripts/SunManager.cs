using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour
{
   public Rigidbody SunRigid;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
		if((SpawnLevel.LevelsGenerated*1.5f) <= 35){
	   SunRigid.velocity = new Vector3(0,0,-1 * (SpawnLevel.LevelsGenerated*0.5f));
		}else{
	   SunRigid.velocity = new Vector3(0,0,-1 * (35));	
		}
    }
	
	
}
