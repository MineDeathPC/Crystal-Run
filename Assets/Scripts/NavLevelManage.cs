using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class NavLevelManage : MonoBehaviour
{
     NavMeshSurface mesh;
		
    void Start()
    {
		mesh = gameObject.GetComponent<NavMeshSurface>();
		UpdateMainNavMesh();
    }

  
   public void UpdateMainNavMesh()
   {
	  mesh.BuildNavMesh();
   }
}
