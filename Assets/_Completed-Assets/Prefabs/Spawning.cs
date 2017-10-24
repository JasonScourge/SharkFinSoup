using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {
	public GameObject shark;
	public GameObject[] topSide;
	public GameObject[] btmSide;
	public GameObject[] leftSide;
	public GameObject[] rightSide;
	
	/// The values of these are overwritten in the engine editor
	/// So if possible, change the values in the engine editor menu itself
	public int minNumOfSharks = 2;
	public int maxNumOfSharks = 4;
	public int start = 2;
	public int interval = 5;
	public float increaseSpeedAmount = 10.0f;

	private GameObject[] chosenSpawnSide1;
	private GameObject[] chosenSpawnSide2;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawningSharks", start, interval);
	}

	// Update is called once per frame
	void Update () {

	}

	void spawningSharks(){

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

		initList(trackSpawnPoints1, chosenSpawnSide1);
		initList(trackSpawnPoints2, chosenSpawnSide2);

		spawningSharks(numOfSharks1, trackSpawnPoints1, randSide1, chosenSpawnSide1);
		spawningSharks(numOfSharks2, trackSpawnPoints2, randSide2, chosenSpawnSide2);
	}
	
	void spawningSharks(int numOfSharks, List<int> trackSpawnPoints, int randSide, GameObject[] chosenSpawnSide){
		// Randomising spawn points of the sharks
		for (int i = 0; i < numOfSharks; i++){
			int indexRand = Random.Range(0, trackSpawnPoints.Count - 1);
			int rand = trackSpawnPoints[indexRand];
			trackSpawnPoints.RemoveAt (indexRand);

			// Creating the object and the chosen spawn point 
			Vector2 chosenSpawnPoint = chosenSpawnSide[rand].transform.position;
			GameObject item = Instantiate (shark, chosenSpawnPoint, Quaternion.identity);
			
			// Changing the speed and direction of the objects moving
			float plusSpeed = item.GetComponent<MoveIt> ().speed + increaseSpeedAmount;
			item.GetComponent<MoveIt> ().setSpeed(plusSpeed);
			
			// Determine which direction to move in 
			/// 1 - top side, 2 - btm side, 3 - left side, 4 - right side
			/// Default increase in speed is 10 ms
			Vector2 chosenDirection = new Vector2 (plusSpeed, plusSpeed);
			switch (randSide) {

				case 1:
					chosenDirection = new Vector2 (0, -plusSpeed);
					break;

				case 2:
					chosenDirection = new Vector2 (0, plusSpeed);
					break;

				case 3:
					chosenDirection = new Vector2(plusSpeed, 0);
					break;

				case 4:
					chosenDirection = new Vector2(-plusSpeed, 0);
					break;

			}

			item.GetComponent<MoveIt>().setDirection (chosenDirection);
		}
	}

	void initList( List<int> listSpawn, GameObject[] chosenSpawnSide){
		for (int i = 0; i < chosenSpawnSide.Length; i ++){
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
