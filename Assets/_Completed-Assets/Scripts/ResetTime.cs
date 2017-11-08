using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class ResetTime : MonoBehaviour {
	
	// Use this for initialization
	void Start() {
		Time.timeScale = 1.0f;
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate() {
		
	}
}