using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {
	public GameObject shark;
	public GameObject[] spawnSide1;
	public GameObject[] spawnSide2;
	public GameObject[] spawnSide3;
	public GameObject[] spawnSide4;

	public int minNumOfSharks = 1;
	public int maxNumOfSharks = 5;
	public int start;
	public int interval;

	public float increaseSpeedAmount = 2.0f;

	private GameObject[] chosenSpawnSide;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnRocks", start, interval);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnRocks(){
		// Randomly selecting which side the Sharks will spawn from 
		int randSide = Random.Range (1, 5);

		// 1 - top side, 2 - btm side, 3 - left side, 4 - right side
		switch (randSide) {
		case 1:
			chosenSpawnSide = spawnSide1;
			break;

		case 2:
			chosenSpawnSide = spawnSide2;
			break;

		case 3:
			chosenSpawnSide = spawnSide3;
			break;

		case 4:
			chosenSpawnSide = spawnSide4;
			break;
		}

		// Randomising the number of sharks, default is from 1 to 5
		/* Built-in error prevention to prevent index out of bound error if the values of sharks more than array length */
		int numOfSharks = Mathf.Min(Random.Range(minNumOfSharks, maxNumOfSharks), chosenSpawnSide.Length);

		// Creating and tracking spawn points
		List<int> trackSpawnPoints = new List<int>();
		for (int i = 0; i < chosenSpawnSide.Length; i++){
			trackSpawnPoints.Add (i);
		}

		// Randomising Spawn Points of the Shark
		for (int i = 0; i < numOfSharks && trackSpawnPoints.Count > 0; i++) {
			
			// Randomising Spawn Points
			int indexRand = Random.Range(0, trackSpawnPoints.Count - 1); 
			int rand = trackSpawnPoints[indexRand];
			trackSpawnPoints.RemoveAt (indexRand);

			// Creating the object and the chosen spawn point 
			Vector2 chosenSpawnPoint = chosenSpawnSide[rand].transform.position;
			GameObject item = Instantiate (shark, chosenSpawnPoint, Quaternion.identity);

			// Changing the speed and direction of the objects moving
			float speed = item.GetComponent<MoveIt> ().speed + increaseSpeedAmount;
			item.GetComponent<MoveIt> ().speed = speed;

			// Determine which direction to move in 
			/* 1 - top side, 2 - btm side, 3 - left side, 4 - right side */
			Vector2 chosenDirection;
			switch (randSide) {
			case 1:
				chosenDirection = new Vector2 (0, -speed);
				break;

			case 2:
				chosenDirection = new Vector2 (0, speed);
				break;

			case 3:
				chosenDirection = new Vector2(speed, 0);
				break;

			case 4:
				chosenDirection = new Vector2(-speed, 0);
				break;

			// Shouldn't happen but setting it just in case and to solve compilation errors
			default:
				chosenDirection = new Vector2 (speed, speed);
				break;
			}

			item.GetComponent<MoveIt>().setDirection (chosenDirection);
		}
	}
}
