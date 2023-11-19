using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternalShopSystem : MonoBehaviour
{

  public static void UpdateHighScore()
   {
	 GameObject.Find("HighestScore").GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString(); 
   }
}
