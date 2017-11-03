using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosingScene : MonoBehaviour {
	
	public void tryAgain() {
		SceneManager.LoadScene (1);
	}

	public void home() {
		SceneManager.LoadScene (0);
	}


}
