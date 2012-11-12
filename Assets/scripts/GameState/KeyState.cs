using UnityEngine;
using System.Collections;

public class KeyState : MonoBehaviour {

	public enum KeyStateValue
	{
		none,
		stop,
		attack,
		move,
		cnt
	};
	
	KeyStateValue currentState;
	
	public void SetKeyState(int test)
	{
		currentState = (KeyStateValue)test;
	}
	
	public void SetKeyCancle()
	{
		currentState = KeyStateValue.none;
	}
	
	public KeyStateValue GetKeyCancle()
	{
		return currentState;
	}
}
