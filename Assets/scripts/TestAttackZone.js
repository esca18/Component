#pragma strict

function OnTriggerEnter(coll : Collider){
	if(coll.gameObject.tag == "ATTACKZONE")
		Debug.Log("active attack");
}


function OnTriggerExit (coll : Collider){
	if(coll.gameObject.tag == "ATTACKZONE")
		Debug.Log("stop attack");
}
