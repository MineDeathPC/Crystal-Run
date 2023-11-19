using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class TerrainTile : MonoBehaviour
{
	SpawnLevel groundSpawner;
	
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<SpawnLevel>();
    }
	
	private void OnTriggerExit(Collider other){
		if(other.gameObject.name == "player")
		{
		groundSpawner.SpawnTerrain();
		Destroy(gameObject,groundSpawner.TileDestroyInSec);
		}
	}

}
