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
	private float speedTrackerMultiplier = 1.0f;

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
		int tempIndex = Random.Range(0, randSides.Count);
		int randSide1 = randSides[tempIndex];
		randSides.RemoveAt (tempIndex); 

		int randSide2 = randSides[Random.Range(0, randSides.Count)];

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

		// Keeping track and increasing the speed track multiplier
		speedTrackerMultiplier += 1.0f;
	}

	void spawningSharks(int numOfSharks, List<int> trackSpawnPoints, int randSide, GameObject[] chosenSpawnSide){
		// Randomising spawn points of the sharks
		for (int i = 0; i < numOfSharks; i++){
			int indexRand = Random.Range(0, trackSpawnPoints.Count);
			int rand = trackSpawnPoints[indexRand];
			trackSpawnPoints.RemoveAt (indexRand);

			// Creating the object and the chosen spawn point 
			Vector2 chosenSpawnPoint = chosenSpawnSide[rand].transform.position;
			GameObject item = Instantiate (shark, chosenSpawnPoint, Quaternion.identity);

			// Changing the speed and direction of the objects moving
			/// Default increase in speed is 10 ms
			float plusSpeed = item.GetComponent<MoveIt>().getSpeed() + speedTrackerMultiplier * increaseSpeedAmount;
			item.GetComponent<MoveIt> ().setSpeed(plusSpeed);

			// Determine which direction the shark should move in 
			Vector2 chosenDirection = new Vector2 (plusSpeed, plusSpeed);
			switch (randSide) {
				case 1:	// top side
					//item.transform.Rotate(Vector3.right);
					chosenDirection = new Vector2 (0, -plusSpeed);
					break;

				case 2:	// btm side
					item.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
					chosenDirection = new Vector2 (0, plusSpeed);
					break;

				case 3:	// left side
					// Sharks face to right right from the left by default
					chosenDirection = new Vector2(plusSpeed, 0);
					break;

				case 4:	// right side
					item.transform.Rotate(new Vector3(0.0f, 180.0f, 1.0f));
					chosenDirection = new Vector2(plusSpeed, 0);
					break;
			}

			item.GetComponent<MoveIt>().setDirection (chosenDirection);
		}
	}

	// Creates the list of spawns to be randomised
	void initList( List<int> listSpawn, GameObject[] chosenSpawnSide){
		for (int i = 0; i < chosenSpawnSide.Length; i ++){
			listSpawn.Add(i);
		}
	}

	// Deciding which side based on the number
	GameObject[] pickingSides(int side){
		GameObject[] chosenSpawnSide = topSide;
		switch (side) {
			case 1:	// top side
				chosenSpawnSide = topSide;
				break;

			case 2:	// btm side
				chosenSpawnSide = btmSide;
				break;

			case 3:	// left side
				chosenSpawnSide = leftSide;
				break;

			case 4:	// right side
				chosenSpawnSide = rightSide;
				break;

			default:
				chosenSpawnSide = null;
				print("Something happened at picking sides");
				break;
		}

		return chosenSpawnSide;
	}
}
