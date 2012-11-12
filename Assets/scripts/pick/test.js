#pragma strict

var test1 : float;

function Start () {
	Debug.Log("enter");
	test1 = 2.0f;
	Debug.Log("enter test : " + test1);
}

function Update () {

}

function GetTest():int
{
	Debug.Log("GetTest");
	return test1;
}