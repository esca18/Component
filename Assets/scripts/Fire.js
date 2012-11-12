#pragma strict
var speed : float = 10.0f;
var thisTransform : Transform;

function Start () {
	thisTransform = GetComponent(Transform);
	FireBullet();
}

function Update () {

}

function FireBullet() {
	//rigidbody.AddForce(thisTransform.transform.forward * speed);
}