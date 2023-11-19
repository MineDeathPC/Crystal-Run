using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
	
	public int damage;
	public ParticleSystem projectileHitParticle;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void OnCollisionEnter(Collision collision){
	   if(GameObject.Find("player") != null){
		 if(collision.gameObject.name == "player"){
		 DeathSystem.health = DeathSystem.health - damage;
		 projectileHitParticle.Play();
		 }
	   }
   }
}
