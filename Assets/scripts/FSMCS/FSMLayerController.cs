using UnityEngine;
using System.Collections;

//per character
public class FSMLayerController : MonoBehaviour {

	public MovementLayer m_layer;
	public ActionLayer a_layer;
	
	void Awake() {
		m_layer = new MovementLayer();
		a_layer = new ActionLayer();
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		m_layer.Update();
		a_layer.Update();
	}
}
