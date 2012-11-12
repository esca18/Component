using UnityEngine;
using System.Collections;

public class Pickingclass : MonoBehaviour{
	
	RaycastHit lastHit;
	int layerMask = 1 << 8;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
	    if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
    	{
        	lastHit = hit;
			this.transform.position = new Vector3(lastHit.point.x, lastHit.point.y, lastHit.point.z);
			
			//Debug.Log("pilayerMaskpck : " + lastHit.point.x.ToString() + " " +  lastHit.point.y.ToString() + " " +lastHit.point.z.ToString());
  		}
	}
}
