using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
   
   public GameObject TurretHead;
   public GameObject RotationCenter;
   [HideInInspector]
   public Transform Target;
   [HideInInspector]
   public bool foundPlayer = false;
   public Transform shootpoint;
   public float warmUp;
   public int repeat;
   public ParticleSystem launchParticles;
   public GameObject projectile;
   public AudioSource shootAudio;
   RaycastHit hit;
  
   
    [HideInInspector]
	LayerMask mask;
   
   
   
   void DrawLine(Vector3 start, Vector3 end, float duration)
         {
             GameObject myLine = new GameObject();
             myLine.transform.position = start;
             myLine.AddComponent<LineRenderer>();
             LineRenderer lr = myLine.GetComponent<LineRenderer>();
            // lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
             lr.startColor = Color.red;
             lr.endColor = Color.red;
             lr.SetWidth(0.1f, 0.1f);
             lr.SetPosition(0, start);
             lr.SetPosition(1, end);
             GameObject.Destroy(myLine, duration);
         }
		 
		 
		 
   
    void Start()
    {
        if(GameObject.Find("player") != null){
		foundPlayer = true;
		Target = GameObject.Find("player").transform;
		int repeat = Random.Range(1,4);
		}
		 
		 mask =  LayerMask.GetMask("turret");
    }






    
    void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "player"){
		InvokeRepeating("TurretActive",warmUp,repeat);
		}
	}
	
	void OnTriggerExit(Collider col){
	if(col.gameObject.name == "player"){
		CancelInvoke("TurretActive");
	}		
	}
	
	
	
	
	
	
	
	void TurretActive()
	{
		if(GameObject.Find("player") != null){
			
			int decide = Random.Range(0,2);
			
			if(decide == 1){
			if(foundPlayer == true){
	Vector3 targetVector = new Vector3(Target.position.x, 
                                        this.transform.position.y, 
                                        Target.position.z );
    TurretHead.transform.LookAt(targetVector);
	
		}
			
		launchParticles.Play();
		if(Physics.Raycast(shootpoint.position, shootpoint.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,Physics.DefaultRaycastLayers,QueryTriggerInteraction.Ignore)){
		
		
		DrawLine(shootpoint.position,hit.collider.transform.position,0.2f);
		GameObject projectiles = Instantiate(projectile,shootpoint.transform.position,shootpoint.transform.rotation);
		projectiles.transform.position = shootpoint.transform.position;
		projectiles.transform.parent = shootpoint.transform;
		//Vector3 direction = projectiles.transform.position - hit.collider.transform.position;
		//Vector3 newVector = direction * 500.0f;
		//projectiles.GetComponent<Rigidbody>().velocity = newVector;
		//projectiles.GetComponent<Rigidbody>().AddForce(Vector3.left * 2000);
		projectiles.transform.LookAt(hit.collider.transform.position);
		projectiles.GetComponent<Rigidbody>().AddForce((hit.collider.transform.position - projectiles.transform.position) * 90);
		shootAudio.Play();
		Destroy(projectiles,3f);
		Debug.Log("hit " + hit.collider.gameObject.name);	
		}
			}
		
		}
	}
	
	
}
