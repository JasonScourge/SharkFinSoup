﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject pauseButton;
	public GameObject[] countdown;

	private float StoredTime; 
	private bool isPaused = false;

	public void startGame() {
		SceneManager.LoadScene (1);
	}

	public void Update (){
		/// Be careful when using Input.GetKey, Input.GetKeyDown and Input.GetKeyUp
		/// They mean very different things
		/// Read the suggestions or documentations in detail before choosing which one to use
		if (Input.GetKeyDown("p")) {
			// Necessary to check if it is paused or not before deciding to pause or unpause
			if (!isPaused) {
				isPaused = true;
				pauseGame ();
			} else {
				isPaused = false; 
				resumeGame ();
			}
		}
	}
		
	public void exitGame() {
		Application.Quit ();
	}

	public void pauseGame(){
		// Store the current game time
		StoredTime = Time.timeScale;

		// This one is to stop the time
		Time.timeScale = 0.00001f;

		// Removes the pause button and creates pause screen
		pauseMenu.SetActive (true);
		pauseButton.SetActive (false);

		// Update current state if it is paused or not
		isPaused = true;
	}

	public void resumeGame(){
		// Recreates the pasue button and deactivates the pause screen
		pauseMenu.SetActive (false);
		pauseButton.SetActive (true);

		// Triggering the countdown
		StartCoroutine ("resumeTiming");
	}

	IEnumerator resumeTiming() {
		// This loop handles the countdown timer display
		for (int i = 0; i < countdown.Length; i++) {
			if (i == 0) {
				countdown [i].SetActive (true);
			} else {
				countdown [i].SetActive (true);
				countdown [i - 1].SetActive (false);
			}
			yield return new WaitForSecondsRealtime (1.1f);
		}
		countdown [countdown.Length - 1].SetActive (false);

		// Returning the game back to its last saved game speed
		Time.timeScale = StoredTime;

		// Updates current state
		isPaused = false;
	}
}
