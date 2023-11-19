using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
	
	public Button ShopButton;
	public Button BackShop;
	public GameObject MainMenuMASTER;
	public GameObject ShopMASTER;
  
    void Start()
    {
	 Button btn = ShopButton.GetComponent<Button>();
	 Button btnback = BackShop.GetComponent<Button>();
     btn.onClick.AddListener(EnterShop);
     btnback.onClick.AddListener(LeaveShop);
    }
	
	void EnterShop()
	{
	 MainMenuMASTER.SetActive(false);
	 ShopMASTER.SetActive(true);
	 InternalShopSystem.UpdateHighScore();
	}
	
	void LeaveShop()
	{
	 MainMenuMASTER.SetActive(true);
	 ShopMASTER.SetActive(false);
	}
}
