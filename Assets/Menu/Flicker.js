#pragma strict

var FlashingLight : Light;
FlashingLight.enabled = false;


function FixedUpdate () {

var RandomNumber = Random.value;


    if(RandomNumber<=.9){
    FlashingLight.enabled = true;
    
    }
    else
    FlashingLight.enabled=false;
}