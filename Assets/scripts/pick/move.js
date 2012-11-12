#pragma strict

var speed : float;
var pick : GameObject;
var temp : Vector3;
//var com : test;

function Start () {
	speed = 10.0f;
	temp.x = 0.0f;
	temp.y = 1.0f;
	temp.z = 0.0f;
	
	//com =  GetComponent(test);
}

function Update () {

	if(Input.GetMouseButton(1))
	{			
		temp.x = pick.transform.position.x;
		temp.y = 1.0f;
		temp.z = pick.transform.position.z;
		
	}
	
	transform.LookAt(temp);
	transform.position = Vector3.MoveTowards(transform.position, temp, Time.deltaTime * speed);
	
		
	//Debug.Log("test : " + com.GetTest());
	Debug.Log("test : " + GetComponent(test).GetTest());
		
	//Debug.Log("test : " + gameObject.GetComponent("test").GetTest());
}