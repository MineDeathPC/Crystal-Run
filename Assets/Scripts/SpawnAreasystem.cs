using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreasystem : MonoBehaviour
{
    SpawnLevel groundSpawner;
	
    void Start()
    {
     groundSpawner = GameObject.FindObjectOfType<SpawnLevel>();	 
    }
	
	private void OnTriggerExit(Collider other){
		if(other.gameObject.name == "player")
		{
		groundSpawner.SpawnTile();
		Destroy(gameObject,groundSpawner.TileDestroyInSec);
		}
	}

}
