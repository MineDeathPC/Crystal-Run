using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MonoBehaviour
{  

    public GameObject rotationcenter;
	[HideInInspector]
	private float degreePerSec;
	public float MaxDegreePerSec;
	private float MinDegreePerSec = 5;
  
    void FixedUpdate()
    {
		degreePerSec = Random.Range(MinDegreePerSec,MaxDegreePerSec+1);
		if(gameObject.name != "blades"){
        transform.RotateAround(rotationcenter.transform.position, Vector3.up, degreePerSec);
		}
		else{
		transform.RotateAround(rotationcenter.transform.position, Vector3.forward, degreePerSec/50);
		}
    }
}
