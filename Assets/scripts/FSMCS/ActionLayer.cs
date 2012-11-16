using UnityEngine;
using System.Collections;

public class ActionLayer {
	//Input.GetKey(KeyCode.S)
		
	KeyCode CurrentKey;
	Vector3 CommandPOS;
	Transform CurrnetTRF;
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {		
		switch(CurrentKey){
		case KeyCode.H:
			Debug.Log("InHold");
			break;
		case KeyCode.Mouse1:
			Debug.Log("InMove");
			break;
		}
		
		SetCurrnetPOS();
	}
	
	public void SetKeyUp(KeyCode key){
		CurrentKey = key;
	}
	
	public void SetCommandPOS(Vector3 pos){
		CommandPOS = pos;
	}
	public void SetTransform(Transform trf){
		CurrnetTRF = trf;
	}
}
