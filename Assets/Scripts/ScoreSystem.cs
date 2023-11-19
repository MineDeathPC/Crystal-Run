using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
  public Text scoretext;
  public static int Score;
  
  void Update(){
	Score = Mathf.RoundToInt((Mathf.RoundToInt(SpawnLevel.LevelsGenerated/6) + PointSystem.TotalPoints/2)-1);
	scoretext.text = "Score:"+Score.ToString();
  }
}
