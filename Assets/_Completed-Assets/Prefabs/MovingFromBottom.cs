using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFromBottom: MonoBehaviour {

	public float speed = 50f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2(0, speed) * Time.deltaTime);
	}
}
