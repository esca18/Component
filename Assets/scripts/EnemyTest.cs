using UnityEngine;
using System.Collections;

public class EnemyTest : MonoBehaviour {
	
	public static bool find;
	private TestAttackZone jsScript;
	
	void Awake(){
		jsScript = this.GetComponent<TestAttackZone>();
	}
	// Use this for initialization
	void Start () {
		find = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		find = jsScript.SeccessFind;
	}
	
	public static bool getFind()
	{
		return find;
	}
}
