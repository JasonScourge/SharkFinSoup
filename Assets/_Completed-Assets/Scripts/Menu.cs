using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject instructionPanel;
	public GameObject creditPanel;

	public void startGame() {
		SceneManager.LoadScene (1);
	}

	public void openInstruction() {
		instructionPanel.SetActive (true);
	}

	public void closeInstruction() {
		instructionPanel.SetActive (false);
	}

	public void openCredit() {
		creditPanel.SetActive (true);
	}

	public void closeCredit() {
		creditPanel.SetActive (false);
	}

	public void exitGame() {
		Application.Quit ();
	}


}
