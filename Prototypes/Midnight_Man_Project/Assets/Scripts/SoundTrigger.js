#pragma strict

var soundTrigger:AudioClip;

function OnTriggerExit(o:Collider){
	Debug.Log("Audio Playing");
	audio.PlayOneShot(soundTrigger);
}