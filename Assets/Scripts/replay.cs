using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
     
	 public Button ReplayButton;
	
	
    void Start()
    {
        Button btn = ReplayButton.GetComponent<Button>();
		btn.onClick.AddListener(Replay);
    }

  
	
	void Replay()
	{
	 SceneManager.LoadScene("MainMenu");
	 DeathSystem.health = 100.0f;
	 SpawnLevel.LevelsGenerated = 0;
	 //PointSystem.TotalPoints = 0;
	 SaveData();
	 ScoreSystem.Score = 0;
	}
	
	
	
	void SaveData()
	{ 
		if(PlayerPrefs.GetInt("HighScore") != null){
			//can save
			if(ScoreSystem.Score > PlayerPrefs.GetInt("HighScore")){
				PlayerPrefs.SetInt("HighScore",ScoreSystem.Score);
			    Debug.Log("New High Score! : SSS: " + ScoreSystem.Score + ", Stored HIGHSCORE : " + PlayerPrefs.GetInt("HighScore").ToString());
			}

		}
		else if(PlayerPrefs.GetInt("HighScore") == null){
			//cant save
			PlayerPrefs.SetInt("HighScore",ScoreSystem.Score);
		}
	}
}
