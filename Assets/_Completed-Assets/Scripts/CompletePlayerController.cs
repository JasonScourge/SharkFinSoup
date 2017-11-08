using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour {
	public GameObject deathScreen;
	public float playerSpeed;		//Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
	private int count;				//Integer to store the number of pickups collected so far.
	private bool hasLost; 			//To determine if the game is over yet.
	private float updateRespawn;	//Respawn timer for the rocks.

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

		//Initialize count to zero.
		count = 1;

		//Initialize win to false.
		hasLost = false; 
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Store the current time in the float currentTime.
		float currentTime = Time.deltaTime;

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (playerSpeed * moveHorizontal, playerSpeed * moveVertical);

		if (hasLost) {
			// Preventing the object to move any further.
			playerSpeed = 0;
		} else {
			// Using transform.translate to create player movement
			transform.Translate (movement * Time.deltaTime);
		}
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			//Add one to the current value of our count variable.
			count = count - 1;

			if (count <= 0) {
				hasLost = true; 
			}
				
			if (hasLost) {
				gameObject.SetActive (false);
				endGame ();
			}
		}
	}

	void endGame() {
		SceneManager.LoadScene (2);
	}
}