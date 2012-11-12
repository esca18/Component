#pragma strict

public var SeccessFind : boolean = false;

function Awake(){
	SeccessFind = false;
}
function OnTriggerEnter(coll : Collider){
	if(coll.gameObject.tag == "ATTACKZONE"){
		Debug.Log("active attack");
		SeccessFind = true;
	}
}


function OnTriggerExit (coll : Collider){
	if(coll.gameObject.tag == "ATTACKZONE"){
		Debug.Log("stop attack");
		SeccessFind = false;
	}
}
