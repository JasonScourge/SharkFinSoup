using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIt : MonoBehaviour {
	public float speed = 5f;

	private Vector2 dir; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Moves from top to down
		transform.Translate (dir * Time.deltaTime);
	}

	public void setDirection(Vector2 chosenDir){
		dir = chosenDir;
	}

	public void setSpeed (float chosenSpeed){
		speed = chosenSpeed;
	}

	public float getSpeed(){
		return speed;
	}
}
