#pragma strict

var FlashingLight : Light;
FlashingLight.enabled = false;

public var randomFrequency : float; // the lower the less naka-on light
public var flickerTimeInterval : float; // every ilang secs mag fflicker
public var flickerTimeDuration : float;

//var shouldFlicker = false;
private var nextFlickerTime : float;
private var flickerEndTime : float;
var isFlickering;


function Start() {
	nextFlickerTime = Time.time + flickerTimeInterval;
	isFlickering = false;
}

function FixedUpdate () {

	var RandomNumber = Random.value;

	if (checkIfShouldFlicker()){
		// originally 0.9
	    if(RandomNumber<=randomFrequency){
	    FlashingLight.enabled = true;
	    
	    }
	    else
	    FlashingLight.enabled=false;
    }
    else FlashingLight.enabled=true;

}

function checkIfShouldFlicker(){
	if(isFlickering){
		if(Time.time >= flickerEndTime){
			nextFlickerTime = Time.time + flickerTimeInterval;
			isFlickering = false;
			return false;
		}
		else return true;
	}
	else {
		if(Time.time >= nextFlickerTime){ // starts here
			flickerEndTime = Time.time + flickerTimeDuration;
			isFlickering = true;
			return true;
		}
		else return false;
	}

}