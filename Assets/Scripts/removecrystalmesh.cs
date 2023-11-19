using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removecrystalmesh : MonoBehaviour
{
	private GameObject meshObj;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject.GetComponent<MeshFilter>(),1);
    }

}
