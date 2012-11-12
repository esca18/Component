#pragma strict
enum testEnum
{
	idle,
	move,
	attack,
	die
};
var MyState : int;
function Start () {
	MyState = testEnum.idle;
}

function Update () {

}