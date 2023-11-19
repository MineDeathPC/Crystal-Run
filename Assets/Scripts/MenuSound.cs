using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
   
     public AudioSource MenuAudio;
	 
	 
    void Start()
    {
		MenuAudio.loop = true;
        MenuAudio.Play();
    }

}
