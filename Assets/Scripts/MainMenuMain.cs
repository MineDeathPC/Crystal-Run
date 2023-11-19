using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuMain : MonoBehaviour
{
    public Button playGameButton;
	
	
	void Start () {
		Button btn = playGameButton.GetComponent<Button>();
		btn.onClick.AddListener(PlayGame);
	}
    void PlayGame(){
		Debug.Log ("Play Button Clicked!");
		SceneManager.LoadScene("MainGameScene");
	}
}
