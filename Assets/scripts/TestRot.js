#pragma strict

function Start () {

}

var target : Transform;

function Update () {
	var relative : Vector3 = transform.InverseTransformPoint(target.position);
	var angle : float = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
	transform.Rotate (0, angle, 0);
}