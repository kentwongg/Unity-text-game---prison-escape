using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, bar, sheets_0, lock_0, cell_bar, sheets_1, lock_1, freedom}; // enum states
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;  // default state
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) 			{state_cell ();} 
		else if (myState == States.sheets_0) 	{state_sheets_0 ();}
		else if (myState == States.sheets_0) 	{state_sheets_1 ();} 
		else if (myState == States.lock_0) 		{state_lock_0();}
		else if (myState == States.lock_1) 		{state_lock_1();}
		else if (myState == States.bar) 		{state_bar();}
		else if (myState == States.cell_bar) 	{state_cell_bar();}
		else if (myState == States.freedom) 	{state_freedom();}
	} // end of update logic

	void state_cell () {
		text.text = "You awake from a deep slumber, your head feels numb. You are on a bed"+
					"It appears that you are in a dank dungeon. You are heavily bruised. You notice a bar loose by the bed.. "+
					"You see a locked door\n\n"+
					"Press S to look at the sheets, B to examine the bar, L key to look at the lock";
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_0;}
		else if (Input.GetKeyDown(KeyCode.B)) {myState = States.bar;}
	}
	
	void state_cell_bar () {
		text.text = "You're still here...but you have a steel bar pipe in your hand. It smells danker by the second."+
					"Press S to look at the sheets, L key to look at the lock";
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_1;}
	}

	void state_sheets_0 () {
		text.text = "Your sheets reek of ammonia and death. You need to get out of here soon." +
					" Press R to return!";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void state_sheets_1 () {
		text.text = "Place still smells like death. You have your bar. Think. Think" +
			" Press R to return!";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_bar;}
	}
	
	void state_lock_0 () {
		text.text = "The lock is rattled and rusty lock pad. You realize it could be broken if you had an object" +
					" Press R to return looking at your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void state_lock_1 () {
		text.text = "The lock is rattled and rusty lock pad. It looks old and damaged. You could try swinging your bar at it?" +
			" Press R to return looking at your cell.\n\n"+
			" Press B to swing your bar at the padlock";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_bar;}
		else if (Input.GetKeyDown(KeyCode.B)) {myState = States.freedom;}
	}

	void state_bar () {
		text.text = "You see a bar thats loose from the bed frame.\n\n\"+" +
					"Press B to grab the bar or R to return looking at your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.B)) {myState = States.cell_bar;}
	}

	void state_freedom () {
		text.text = "You are free...you walk out....";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.B)) {myState = States.cell_bar;}
		else if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
	}


} //end of class
