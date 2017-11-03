using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject pauseButton;

	private float StoredTime; 
	private bool isPaused = false;

	public void startGame() {
		SceneManager.LoadScene (1);
	}

	public void Update (){
		if (Input.GetKeyDown("p")) {
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
		// This one is to stop the time
		StoredTime = Time.timeScale;
		Time.timeScale = 0.00001f;
		pauseMenu.SetActive (true);
		pauseButton.SetActive (false);
	}

	public void resumeGame(){
		Time.timeScale = StoredTime;
		pauseMenu.SetActive (false);
		pauseButton.SetActive (true);
	}
}
