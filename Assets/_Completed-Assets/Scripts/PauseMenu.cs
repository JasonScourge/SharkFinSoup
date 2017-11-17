using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject pauseButton;
	public GameObject player;
	public GameObject[] countdown;

	private float StoredTime; 
	private bool stopPause;
	private bool isPaused;

	public void startGame() {
		isPaused = false;
		stopPause = false;
		SceneManager.LoadScene (1);
	}

	public void Update (){
		// Disable the pause function if the player has lost
		if (player.GetComponent<CompletePlayerController>().hasLost) {
			isPaused = true;
		}

		/// Be careful when using Input.GetKey, Input.GetKeyDown and Input.GetKeyUp
		/// They mean very different things
		/// Read the suggestions or documentations in detail before choosing which one to use
		if (Input.GetKeyDown("p")) {
			// Necessary to check if it is paused or not before deciding to pause or unpause
			if (!isPaused) {
				pauseGame ();
			} else {
				resumeGame ();
			}
		}
	}

	public void exitGame() {
		Application.Quit ();
	}

	public void pauseGame(){
		if (!stopPause) {
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
	}

	public void resumeGame(){
		if (!stopPause) {
			stopPause = !stopPause;

			// Recreates the pasue button and deactivates the pause screen
			pauseMenu.SetActive (false);
			pauseButton.SetActive (true);

			// Triggering the countdown
			StartCoroutine ("resumeTiming");
		}
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
			yield return new WaitForSecondsRealtime (1.0f);
		}
		countdown [countdown.Length - 1].SetActive (false);

		// Returning the game back to its last saved game speed
		Time.timeScale = StoredTime;

		// Updates current state
		yield return new WaitForSecondsRealtime (0.1f);
		isPaused = false;
		stopPause = !stopPause;
	}
}
