using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIt : MonoBehaviour {
	// Can be change in the engine editor
	/// Privatising this variable is also fine
	/// Just that the getter method has to be used instead
	public float speed = 4f;

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
