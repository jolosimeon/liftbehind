#pragma strict
private var lightSource : Light;
var soundTurnOn : AudioClip;
var soundTurnOff : AudioClip;
  
function Start () {
     lightSource = GetComponent(Light);
}
  
function Update () {
	if (Input.GetMouseButtonDown(1)) ToggleFlashLight();
}
  
function ToggleFlashLight () {
	lightSource.enabled=!lightSource.enabled;

	//Audio
	if (lightSource.enabled) {
		GetComponent.<AudioSource>().clip = soundTurnOn;
	} else {
		GetComponent.<AudioSource>().clip = soundTurnOff;
    }
    GetComponent.<AudioSource>().Play();
 }
  
 @script RequireComponent(AudioSource)