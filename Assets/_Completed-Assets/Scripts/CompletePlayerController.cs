﻿using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour {

	public float speed;				//Floating point variable to store the player's movement speed.
	public Text countText;			//Store a reference to the UI Text component which will display the number of pickups collected.
	public Text loseText;			//Store a reference to the UI Text component which will display the 'You win' message.

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

		//Initialze winText to a blank string since we haven't won yet at beginning.
		loseText.text = " ";

		//Call our SetCountText function which will update the text with the current value for count.
		SetCountText ();
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
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		if (hasLost) {
			// Preventing the object to move any further.
			speed = 0;

			// Removing all current velocity from the object.
			rb2d.velocity = Vector2.zero; 
		} else {
			//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
			rb2d.AddForce (movement * speed);
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
			
			//Update the currently displayed count by calling the SetCountText function.
			SetCountText ();

			if (count <= 0) {
				hasLost = true; 
			}
				
			if (hasLost) {
				loseText.text = "You LOSE!";
			}
				
			gameObject.SetActive(false);
			Time.timeScale = 0;
		}
		

	}

	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
	void SetCountText()
	{
		countText.text = "Life: " + count.ToString ();
	}
}
