#pragma strict

function Start () {

}

function Update () {

}

/*
function OnCollisionEnter(coll : Collision){
	if(coll.gameObject.tag == "BULLET"){
		Destroy(coll.gameObject);
	}
}
*/

function OnTriggerEnter(coll : Collider){
	if(coll.gameObject.tag == "BULLET")
		Destroy(coll.gameObject);
}