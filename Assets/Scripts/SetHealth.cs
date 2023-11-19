using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHealth : MonoBehaviour
{
	[HideInInspector]
    public int health;
	public Slider healthBar;
	   DeathSystem deathsystem;
	
    void Start()
    {
		//deathsystem = GameObject.FindObjectOfType<DeathSystem>();
    }

  
    void Update()
    {
      healthBar.value = DeathSystem.health;
    }
}
