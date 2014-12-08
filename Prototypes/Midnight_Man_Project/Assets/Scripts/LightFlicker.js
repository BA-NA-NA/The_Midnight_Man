#pragma strict

@script RequireComponent(Light)

var intensity : float;
var variance : float;
var changeWeight : float;
var flickerRate : float;
var flickering : boolean;

function Start () {

}

function Update () {
	if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0 ){
		if(!flickering){
			variance = variance*2;
			flickering = true;
		}
		if(flickerRate < 0.08){
			flickerRate += 0.002;
		}
	}
	else{
		if(flickering){
			variance = variance/2;
			flickering = false;			
		}
		if(flickerRate > 0.01){
			flickerRate -= 0.002;
		}
	}
	var change : float;
	change = Random.Range(-flickerRate,flickerRate);
	if(light.intensity + change + changeWeight > intensity + variance){
		light.intensity = intensity + variance;
		changeWeight = 0;
	}
	else if(light.intensity + change + changeWeight < intensity - variance){
		light.intensity = intensity - variance;
		changeWeight = 0;
	}
	else{
		changeWeight += change;
		light.intensity += changeWeight;
	}
}