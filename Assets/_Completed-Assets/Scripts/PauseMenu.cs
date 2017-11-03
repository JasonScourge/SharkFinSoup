using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;

	private float StoredTime; 

	public void startGame() {
		SceneManager.LoadScene (1);
	}
		
	public void exitGame() {
		Application.Quit ();
	}

	public void pauseGame(){
		// This one is to stop the time
		StoredTime = Time.timeScale;
		Time.timeScale = 0.00001f;
		pauseMenu.SetActive (true);
	}

	public void resumeGame(){
		/// This one is to stop the time
		Time.timeScale = StoredTime;
		pauseMenu.SetActive (false);
	}
}
