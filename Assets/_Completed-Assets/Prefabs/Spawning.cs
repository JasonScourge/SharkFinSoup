using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {
	public GameObject shark;
	public GameObject[] topSide;
	public GameObject[] btmSide;
	public GameObject[] leftSide;
	public GameObject[] rightSide;
	public int minNumOfSharks = 2;
	public int maxNumOfSharks = 4;
	public int start;
	public int interval;

	public float increaseSpeedAmount = 10.0f;

	private GameObject[] chosenSpawnSide1;
	private GameObject[] chosenSpawnSide2;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnRocks", start, interval);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnRocks(){
		
		// Randomly selecting which side the Sharks will spawn from 
		/// The sharks are guranteed to be spawn from 2 different sides 
		List<int> randSides = new List<int>();
		for (int i = 1; i <= 4; i++) {
			randSides.Add (i);
		}

		// tempIndex cannot be called twice in a row after removal
		/// This is to factor in the corner case that if tempIndex hits 3
		/// This may cause an array out of bound error
		/// Plus creates predictability in the game itself (can change it accordingly)
		int tempIndex = Random.Range(0, randSides.Count - 1);
		int randSide1 = randSides[tempIndex];
		randSides.Remove (tempIndex); 
		int randSide2 = randSides[Random.Range(0, randSides.Count - 1)];

		chosenSpawnSide1 = pickingSides (randSide1);
		chosenSpawnSide2 = pickingSides (randSide2);

		// Randomising the number of sharks, default is from 2 to 4
		/* Built-in error prevention to prevent index out of bound error if the values of sharks more than array length */
		int numOfSharks1 = Mathf.Min(Random.Range(minNumOfSharks, maxNumOfSharks), chosenSpawnSide1.Length);
		int numOfSharks2 = Mathf.Min(Random.Range(minNumOfSharks, maxNumOfSharks), chosenSpawnSide2.Length);

		// Creating and tracking spawn points
		List<int> trackSpawnPoints1 = new List<int>();
		List<int> trackSpawnPoints2 = new List<int>();
		
	}
	
	void initList( List<int> listSpawn, GameObject[] chosenSpawnSide){
		for (int i = 0; i < chosenSpawnSide; i ++){
			listSpawn.Add(i);
		}
	}

	GameObject[] pickingSides(int side){
		GameObject[] chosenSpawnSide;
		switch (side) {
		case 1:
			chosenSpawnSide = topSide;
			break;

		case 2:
			chosenSpawnSide = btmSide;
			break;

		case 3:
			chosenSpawnSide = leftSide;
			break;

		case 4:
			chosenSpawnSide = rightSide;
			break;

		default:
			chosenSpawnSide = topSide;
			break;
		}

		return chosenSpawnSide;
	}
}
