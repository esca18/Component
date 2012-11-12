#pragma strict
var Player : Transform;
var picking : TestPicking;
var pickPos : RaycastHit;
	
function Start () {
	pickPos.point.x = 0.0f;
	//pickPos.point.y = 0.0f;
	pickPos.point.z = 0.0f;
	
	//rigidbody.AddForce(Player.transform.forward * 10.0f);
}

function Update () {

	pickPos = picking.lastHit;

	Debug.Log(pickPos.point.x.ToString() + "," + pickPos.point.y.ToString() + "," + pickPos.point.z.ToString());
	
	
	//Player.transform.Translate(pickPos.point.x, 0.0f, pickPos.point.z);
	
	//Player.transform.position.x = pickPos.point.x;
	//Player.transform.position.y = 1.0f;
	//Player.transform.position.z = pickPos.point.z;
	//Player.transform.Translate(0.0f, 0.00f, 0.0f);
	
	
	Player.transform.position.x = pickPos.point.x;
	Player.transform.position.z = pickPos.point.z;

}