using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject instructionPanel;
	public GameObject creditPanel;
	public GameObject creditPanel2;

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
		creditPanel2.SetActive (false);
	}

	public void exitGame() {
		Application.Quit ();
	}

	public void nextPage(){
		creditPanel.SetActive (false);
		creditPanel2.SetActive (true);
	}

	public void backPage(){
		creditPanel2.SetActive (false);
		creditPanel.SetActive (true);
	}

}
