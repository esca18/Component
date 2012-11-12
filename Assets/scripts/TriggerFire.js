#pragma strict

function OnTriggerEnter(coll : Collider){
	if(coll.gameObject.tag == "BULLET")
		Destroy(gameObject);
}