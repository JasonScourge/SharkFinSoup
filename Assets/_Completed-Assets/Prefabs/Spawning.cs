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
	public int minNumOfSharks;
	public int maxNumOfSharks;
	public int start;
	public int interval;
	public float increaseSpeedAmount = 1.0f;

	private GameObject[] chosenSpawnSide1;
	private GameObject[] chosenSpawnSide2;
	private float speedTrackerMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawningSharks", start, interval);
	}
		
	// FixedUpdate is called at a fixed interval and is independent of frame rate.
	void FixedUpdate () {
		Time.timeScale = 1.0f + speedTrackerMultiplier/85;
	}

	void spawningSharks(){
		// Randomly selecting which side the Sharks will spawn from 
		/// The sharks are guranteed to be spawn from 2 different sides 
		int leftSide1 = 1;
		int rightSide2 = 2;
		chosenSpawnSide1 = pickingSides (leftSide1);
		chosenSpawnSide2 = pickingSides (rightSide2);

		// Randomising the number of sharks, default is from 2 to 4
		/// Built-in error prevention to prevent index out of bound error if the values of sharks more than array length
		int numOfSharks1 = Mathf.Min(Random.Range(minNumOfSharks, maxNumOfSharks), chosenSpawnSide1.Length);
		int numOfSharks2 = Mathf.Min(Random.Range(minNumOfSharks, maxNumOfSharks), chosenSpawnSide2.Length);

		// Creating and tracking spawn points
		List<int> trackSpawnPoints1 = new List<int>();
		List<int> trackSpawnPoints2 = new List<int>();

		initList(trackSpawnPoints1, chosenSpawnSide1);
		initList(trackSpawnPoints2, chosenSpawnSide2);

		spawningSharks(numOfSharks1, trackSpawnPoints1, leftSide1, chosenSpawnSide1);
		spawningSharks(numOfSharks2, trackSpawnPoints2, rightSide2, chosenSpawnSide2);

		// Keeping track and increasing the speed track multiplier
		/// Also keep track and changes interval of spawning at times
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
			float plusSpeed = item.GetComponent<MoveIt>().getSpeed() + increaseSpeedAmount;
			//float plusSpeed = item.GetComponent<MoveIt>().getSpeed() + speedTrackerMultiplier * increaseSpeedAmount;
			item.GetComponent<MoveIt> ().setSpeed(plusSpeed);

			// Determine which direction the shark should move in 
			/// Do understand and brush up your concepts on some physics and matrix manipulation 
			/// Modifying the y axis flips the thing (by 180 degrees)
			/// Modifying the z axis rotates the thing 
			/// Do not modify the x-axis in general
			/// Visualise where you are rotating in 3D space before applying any changes
			/// Do remember than transforming the shark requires a change in the chosenDirection
			Vector2 chosenDirection = new Vector2 (plusSpeed, plusSpeed);
			switch (randSide) {
				case 1:	// left side
					// Sharks face to right right from the left by default
					chosenDirection = new Vector2(plusSpeed, 0); 	
					break;

				case 2:	// right side
					item.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
					chosenDirection = new Vector2(plusSpeed, 0);
					break;

				case 3:	// left side
					// Sharks face to right right from the left by default
					chosenDirection = new Vector2(plusSpeed, 0);
					break;

				case 4:	// right side
					item.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
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
		GameObject[] chosenSpawnSide = leftSide;
		switch (side) {
			case 1:	// left side
				chosenSpawnSide = leftSide;
				break;

			case 2:	// right side
				chosenSpawnSide = rightSide;
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
