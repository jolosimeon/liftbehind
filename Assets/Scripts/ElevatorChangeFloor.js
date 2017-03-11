#pragma strict
var initialPosition;

var goingUp;
var goingToInitial;

var TOP = 7;
var INITIAL = 1.48;
var BOTTOM_START = -5;

function Start () {
	initialPosition = transform.position.y;
	goingUp = false;
	goingToInitial = false;
}

function Update () {

}

function moveElevatorUp(){
	if (!goingUp && !goingToInitial && Input.GetKeyDown(KeyCode.F)) {
		goingUp = true;
	} else if (IsMaxUp()) {
		WarpToBottom();
		goingUp = false;
		goingToInitial = true; 
	} else if (IsAtInitial()) {
		goingToInitial = false;

	}

	if (goingUp || goingToInitial) {
	 	MoveUp();
	}
}

function IsMaxUp() {
	return goingUp && (transform.position.y >= TOP);
}

function IsAtInitial() {
	return goingToInitial && (transform.position.y >= INITIAL);
}

function MoveUp() {
	transform.Translate(Vector3.up * Time.deltaTime, Space.World);
}

function WarpToBottom() {
	transform.position.y = BOTTOM_START;
}

function MakeExactToInitial() {
	transform.position.y = INITIAL;
}