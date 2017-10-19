using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {
	public GameObject sharkRock;
	public GameObject[] allSpawnPoints;
	public int start;
	public int interval;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnRocks", start, interval);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void spawnRocks(){
		int rand = Random.Range(0, allSpawnPoints.Length); 
		Vector2 chosenSpawnPoint = allSpawnPoints[rand].transform.position;
		GameObject item = Instantiate(sharkRock, chosenSpawnPoint, Quaternion.identity);
	}
}
