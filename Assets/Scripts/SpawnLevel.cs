using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;


public class SpawnLevel : MonoBehaviour
{
	
	levelmesh LevelMesh;
	
	
	public GameObject groundTile1;
	public GameObject groundTile2;
	public GameObject groundTile3;
	public GameObject groundTile4;
	public GameObject groundTile5;
	public GameObject groundTile6;
	public GameObject groundTile7;
	public GameObject groundTile8;
	public GameObject groundTile9;
	public GameObject groundTile10;
	public GameObject groundTile11;
	public GameObject groundTile12;
	public GameObject groundTile13;
	
	
	public GameObject GroundTerrain;
	Vector3 terrainNextSpawnPoint = new Vector3(-0.13f,-15.3f,-0.1f);
	
	
	public GameObject spike;
	public int TileDestroyInSec = 6;
	
	public GameObject blueCrystalObject;
	public GameObject purpleCrystalObject;
	public GameObject noCrystalObject;
	public GameObject greenCrystalObject;
	public bool PreventCrystalBlockage;
	public int OverlapSphereRadius;
	public int DestroyCollidedCrystalDelay;
	
	[SerializeField]
	public int CrystalChance;
	[SerializeField]
	public int CrystalScaleMinRaw;
	public int CrystalScaleMaxRaw;
	public int checkCrystalSpawnLimit = 160;
	int CrystalScaleMax;
	int CrystalScaleMin;
	public static int LevelsGenerated = 0;
	Vector3 nextSpawnPoint;
	
	public GameObject EnemyPrefab;
	public GameObject Enemy2Prefab;
	public int minforenemy2;
	public int EnemyScaleMin;
	public int EnemyScaleMax;
	public int EnemyAmountMax;
	[SerializeField]
	public int MaxBladeChance;
	
	
	public GameObject Point;
	
	
	public string BladesCollectionName = "DoomBlades";
    
	
	public void SpawnTile()
	{
		LevelsGenerated = LevelsGenerated + 1;
		
		
		int which = Random.Range(1,14); //(1,13) //(include,exclude) //1,14
		if(which == 1){
		GameObject temp = Instantiate(groundTile1,nextSpawnPoint,Quaternion.identity);
		LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
					GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 180){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 200){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
		SpawnPoint(temp);
			SpawnPoint(temp);
		}
		
		else if(which == 2){
		GameObject temp = Instantiate(groundTile2,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
					GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		}
		
		else if(which == 3){
		GameObject temp = Instantiate(groundTile3,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
					GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
				GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		}
		
		else if(which == 4){
		GameObject temp = Instantiate(groundTile4,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);	
		SpawnPoint(temp);
		}
		
		else if(which == 5){
		GameObject temp = Instantiate(groundTile5,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		}
		
		else if(which == 6){
		GameObject temp = Instantiate(groundTile6,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		
		}
		else if(which == 7){
		GameObject temp = Instantiate(groundTile7,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		}
		
		
		
		
		else if(which == 8){
		GameObject temp = Instantiate(groundTile7,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		}
		
		
		else if(which == 9){
		GameObject temp = Instantiate(groundTile9,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		}
		
		
		
		else if(which == 10){
		GameObject temp = Instantiate(groundTile10,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		}
		
		
		
		
		else if(which == 11){
		GameObject temp = Instantiate(groundTile11,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
				
				
				
				
			}
			
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
			SpawnPoint(temp);
		
		for(int j=0;j<100;j++){
				if(temp.transform.Find("Sphere (" + j + ")") != null){
					int shouldOnTurret = Random.Range(0,3);
					if(shouldOnTurret == 1){
						temp.transform.Find("Sphere (" + j + ")").gameObject.SetActive(true);
					}
				}
				}
		}
		
		
		
		
		
		
		else if(which == 12){
		GameObject temp = Instantiate(groundTile6,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
		SpawnPoint(temp);
		}
		
		else if(which == 13){
		GameObject temp = Instantiate(groundTile13,nextSpawnPoint,Quaternion.identity);
			LevelMesh.UpdateMainNavMesh();
		nextSpawnPoint = temp.transform.Find("Next").transform.position;
		for(int i=0;i<checkCrystalSpawnLimit;i++){
			if(temp.transform.Find("CrystalSpawn (" + i + ")") != null){
				int whichCrystal = Random.Range(1,CrystalChance + 3);
				if(whichCrystal == 1){
					GameObject crystal = Instantiate(blueCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 2){
						GameObject crystal = Instantiate(purpleCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 3){
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
				}
				else if(whichCrystal == 4){
					if(LevelsGenerated > 70){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 5){
					if(LevelsGenerated > 130){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if(whichCrystal == 6){
					if(LevelsGenerated > 190){
					GameObject crystal = Instantiate(greenCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					int CrystalScale = Random.Range(CrystalScaleMin,CrystalScaleMax);
					//crystal.transform.localScale = new Vector3(CrystalScale,CrystalScale,CrystalScale);	
					}
					else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
					}
				}
				else if (whichCrystal >= 7 && whichCrystal <= 9){
                 GameObject crystalspike = Instantiate(spike,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
				 crystalspike.transform.parent = temp.transform;				  
				}
				else{
					GameObject crystal = Instantiate(noCrystalObject,temp.transform.Find("CrystalSpawn (" + i + ")").transform.position,Quaternion.identity);
					crystal.transform.parent = temp.transform;
				}
			}
			
			else{
				
			}
		}
		SpawnEnemy(temp);
		SpawnEnemy2(temp);
		SpawnBlades(temp);
		SpawnPoint(temp);
		}
		
		
		
		
		
	}
	
	
	
	void SpawnEnemy(GameObject spawnedLevel)
	{
	  int randomScale = Random.Range(EnemyScaleMin,EnemyScaleMax + 1);
	  Vector3 EnemyScaleTrue = new Vector3(randomScale, randomScale, randomScale);
	  int Amount = Random.Range(0,EnemyAmountMax + 1);
	   if(spawnedLevel.transform.Find("NoCrystal(Clone)") != null){
		for(int i=0;i< Amount;i++){
		 GameObject enemy = Instantiate(EnemyPrefab,spawnedLevel.transform.Find("NoCrystal(Clone)").transform.position,Quaternion.identity);
		 enemy.transform.parent = spawnedLevel.transform;
		 //enemy.transform.localScale = EnemyScaleTrue;
		}
	   }
	}
	
	
	void SpawnEnemy2(GameObject spawnedLevel){
		int decide = Random.Range(0,2);//0,1
		if(decide == 0){
			//no spawn
		}
		else if(decide == 1){
			if(LevelsGenerated >= minforenemy2){
			 for(int i=0;i < 50;i++){
			  int spawn = Random.Range(0,2);
			  if(spawnedLevel.transform.Find("SuperEnemtSpawn (" + i + ")") != null){
			   if(spawn == 0){
				   
			   }
			   else if(spawn == 1){
				GameObject superEnemy = Instantiate(Enemy2Prefab,spawnedLevel.transform.Find("SuperEnemtSpawn (" + i + ")").transform.position,Quaternion.identity);   
				superEnemy.transform.parent = spawnedLevel.transform;
			   }
			  }
			 }	
			}
		}
	}
	
	
	
	
	
	
	
	void SpawnBlades(GameObject spawnedLevel)
	{
	 int shouldSpawn = Random.Range(0,MaxBladeChance+1); 
	 if(shouldSpawn == MaxBladeChance){
		 if(spawnedLevel.transform.Find(BladesCollectionName) != null){
	      spawnedLevel.transform.Find(BladesCollectionName).gameObject.SetActive(true);
		 }
		 
	 }
	}
	
	
	
	
	
	
	
	void SpawnPoint(GameObject SpawnedLevel)
	{
	if(SpawnedLevel.transform.Find("NoCrystal(Clone)")!= null){
		
		
	GameObject[] objs = GameObject.FindObjectsOfType(typeof(GameObject)).Select(g => g as GameObject).Where(g => g.name == "NoCrystal(Clone)").ToArray();


   foreach(GameObject aPoint in objs){
    int choose1 = Random.Range(0,2);
	if(choose1 == 0 && aPoint.transform.parent == SpawnedLevel.transform){
		return;
		}
	
	else if(choose1 == 1  && aPoint.transform.parent == SpawnedLevel.transform){
	GameObject pointA = Instantiate(Point,aPoint.transform.position, Quaternion.identity);
	
	
	int choose = Random.Range(1,6); 
	switch (choose){
		case 1:
		pointA.transform.Find("Point (1)").GetComponent<Light>().color = Color.red;
		break;
		case 2:
		pointA.transform.Find("Point (1)").GetComponent<Light>().color = Color.yellow;
		break;
		case 3:
		pointA.transform.Find("Point (1)").GetComponent<Light>().color = Color.green;
		break;
		case 4:
		pointA.transform.Find("Point (1)").GetComponent<Light>().color = Color.blue;
		break;
		case 5:
		pointA.transform.Find("Point (1)").GetComponent<Light>().color = Color.white;
		break;
	}
	}
	
	}
	}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	public void SpawnTerrain()
	{
	//Vector3 newlyGenerated = GameObject.Find("next").transform.position;
	
	 GameObject tempTerrain = Instantiate(GroundTerrain,terrainNextSpawnPoint,Quaternion.identity);
	 terrainNextSpawnPoint = tempTerrain.transform.Find("next").transform.position;
	
	}
	
	
	
	
	
	
	
	
	
	
	
    private void Start()
    {
		
		LevelMesh = GameObject.FindObjectOfType<levelmesh>();
		
		CrystalScaleMax = CrystalScaleMaxRaw + 1;
		CrystalScaleMin = CrystalScaleMinRaw;
		for(int i=0;i<6;i++){
        SpawnTile();
	//	SpawnTerrain();
		}
		
	//terrainNextSpawnPoint = new Vector3(-0.13f,-15.3f,-0.1f);	
    }

   
}
