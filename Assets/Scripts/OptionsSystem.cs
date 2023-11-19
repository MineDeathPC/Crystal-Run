using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSystem : MonoBehaviour
{
    
    public Button OptionsButton;
	public Button OptionsBack;
	public GameObject MainMenuMASTER;
	public GameObject OptionsMASTER;
	
  
    void Start()
    {
	 Button btn = OptionsButton.GetComponent<Button>();
	 Button backbtn = OptionsBack.GetComponent<Button>();
     btn.onClick.AddListener(EnterOptions);
     backbtn.onClick.AddListener(BackOptions);
    }
	
	void EnterOptions()
	{
	 MainMenuMASTER.SetActive(false);
	 OptionsMASTER.SetActive(true);
	}
	
	void BackOptions()
	{
	 MainMenuMASTER.SetActive(true);
	  OptionsMASTER.SetActive(false);
	}
}
