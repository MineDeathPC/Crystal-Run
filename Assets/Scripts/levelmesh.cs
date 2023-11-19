/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;


public class levelmesh : MonoBehaviour
{
	  
       NavMeshSurface mesh;
		
    void Start()
    {
		mesh = gameObject.GetComponent<NavMeshSurface>();
    }

  
   public void UpdateMainNavMesh()
   {
	  mesh.BuildNavMesh();
   }
}
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;


public class levelmesh : MonoBehaviour
{
	  
       Component[] mesh;
		
    void Start()
    {
		mesh = gameObject.GetComponents(typeof(NavMeshSurface));
    }

  
   public void UpdateMainNavMesh()
   {
	   foreach(NavMeshSurface surface in mesh )
	  surface.BuildNavMesh();
   }
}
