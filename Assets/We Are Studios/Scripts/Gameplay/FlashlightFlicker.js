#pragma strict

var FlashingLight : Light;
var flashlightAudio : AudioSource;
var flashlightAmbient : AudioSource;
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
    flashlightAmbient.Play();
}

function FixedUpdate () {

    var RandomNumber = Random.value;
    var flashlightOn = true;

    if (checkIfShouldFlicker()){
        // originally 0.9
        if(RandomNumber<=randomFrequency){
            if (!flashlightOn) {
                flashlightAudio.PlayOneShot(flashlightAudio.clip);
                flashlightAmbient.Play();
                flashlightOn = true;
            }
            FlashingLight.enabled = true;
        }
        else {
            if (flashlightOn) {
                flashlightAudio.PlayOneShot(flashlightAudio.clip);
                flashlightAmbient.Stop();
                flashlightOn = false;
            }
            FlashingLight.enabled=false;
        }
            
    }
    else {
        if (!flashlightOn) {
            flashlightAudio.PlayOneShot(flashlightAudio.clip);
            flashlightAmbient.Play();
            flashlightOn = true;
        }
        FlashingLight.enabled = true;
    }

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