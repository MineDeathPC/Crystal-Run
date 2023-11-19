using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPoints : PointSystem
{
    // Start is called before the first frame update
	
	
    void Start()
    {
       TotalPoints = 0;
		Debug.Log("points reset");
    }

}
