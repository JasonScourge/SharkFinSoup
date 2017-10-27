using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintDebug : MonoBehaviour {
	/// This class may be expanded for future use
	/// Right now it just serves its purpose to be just for recording purposes for print code mainly used for debugging

	public void consolePrintLog(){
		/*
		   print ("Current speed it will spawn at: " + item.GetComponent<MoveIt> ().getSpeed ());

		   string msg1 = "Randsides original List = ";
		   for (int i = 0; i < randSides.Count; i+= 1){
		   msg1 = msg1 + randSides[i] + ", ";
		   }
		   print ("Randsides original List = " + msg1);

		   string msg2 = "After removal Randsides: ";
		   for (int i = 0; i < randSides.Count; i+= 1){
		   msg2 = msg2 + randSides[i] + ", ";
		   }
		   print ("Randsides original List = " + msg2);


		   print("Something happened at picking sides");

		   print("Chosen randside2 = " + randSide2);
		 */
	}

	public void previousCode(){
		/*
		   Time.timeScale = 0;

		   GameObject[] pickingSides(int side){
		   GameObject[] chosenSpawnSide = topSide;
		   switch (side) {
		   case 1:	// top side
		   chosenSpawnSide = topSide;
		   break;

		   case 2:	// btm side
		   chosenSpawnSide = btmSide;
		   break;

		   case 3:	// left side
		   chosenSpawnSide = leftSide;
		   break;

		   case 4:	// right side
		   chosenSpawnSide = rightSide;
		   break;

		   default:
		   chosenSpawnSide = null;
		   print("Something happened at picking sides");
		   break;
		   }

		   switch (randSide) {
		   case 1:	// top side
		   item.transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f));
		   chosenDirection = new Vector2 (plusSpeed, 0);
		   break;

		   case 2:	// btm side
		   item.transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
		   chosenDirection = new Vector2 (plusSpeed, 0);
		   break;

		   case 3:	// left side
		// Sharks face to right right from the left by default
		chosenDirection = new Vector2(plusSpeed, 0);
		break;

		case 4:	// right side
		item.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
		chosenDirection = new Vector2(plusSpeed, 0);
		break;
		}

	*/
	}
}
