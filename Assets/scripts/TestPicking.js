#pragma strict

var lastUpdateWasAHit : boolean;
var lastHit : RaycastHit;

var playerCube : Transform;

function Start () {

}

function Update () {

	/*
    var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    var hit : RaycastHit;
    
    var layerMask = 1 << 8;
    //layerMask = ~layerMask;
    
    if(Physics.Raycast(ray, hit, Mathf.Infinity,layerMask) && lastUpdateWasAHit != true)
    {
    	if(hit.collider.gameObject.tag == "PLANE"){
	        // to represent that the picked object is 'selected', we add some gray
	        hit.collider.gameObject.renderer.material.color += Color.grey;
	        lastHit = hit;
	        lastUpdateWasAHit = true;
        
        	playerCube.transform.position.x = lastHit.point.x;
			playerCube.transform.position.z = lastHit.point.z;
		}
        //Debug.Log(lastHit.point.x.ToString() + "," + lastHit.point.y.ToString() + "," + lastHit.point.z.ToString());
        
    }
    else // if raycast didnt hit anything
    // we still gotta clean up our last hit (if any)
    if(lastUpdateWasAHit)
    {
        // remove the gray that we added when it became 'selected'
        lastHit.collider.gameObject.renderer.material.color -= Color.grey;
        lastUpdateWasAHit = false;
    }  
    */
    
    var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    var hit : RaycastHit;
    
    var layerMask = 1 << 8;
    //layerMask = ~layerMask;
    
    if(Physics.Raycast(ray, hit, Mathf.Infinity,layerMask) && Input.GetMouseButton(1))
    {
    	if(hit.collider.gameObject.tag == "PLANE"){
	        // to represent that the picked object is 'selected', we add some gray
	        lastHit = hit;
	        lastUpdateWasAHit = true;
        
        	//playerCube.transform.position.x = lastHit.point.x;
			//playerCube.transform.position.z = lastHit.point.z;
						
			
			var cur : Vector3;
			var pick : Vector3;
			var dot : float;
			var turnRadian : float;
			
			cur = playerCube.transform.position;
			pick = lastHit.point;
			cur.y = 0.0f;
			pick.y = 0.0f;
			
			cur.Normalize();
			pick.Normalize();
			
			dot = Vector3.Dot(cur, pick);
			Debug.Log("dot : " + dot);
			
			var buho : float;
			buho = 1.0f;
			if(dot > 0.0f)
			{
				buho = -1.0f;
			}
			else
			{
				buho = 1.0f;
			}
			
			
			turnRadian = buho * Mathf.Acos(dot) /** Mathf.Rad2Deg*/ ;
			
			
			//playerCube.transform.Rotate(0, turnRadian, 0);
			
			Debug.Log("radian : " + turnRadian);
			var target = Quaternion.Euler (0, turnRadian, 0);
			
			//playerCube.transform.Rotate(Vector3.up, turnRadian);
			playerCube.transform.rotation = Quaternion.Slerp(playerCube.transform.rotation, target, 2.0f);

			//playerCube.transform.rotation(0, turnRadian, 0);
			
			
			//var cur : Vector3;
			//cur = lastHit.point;
			//cur.Normalize();
			//cur.y = 0;
			//playerCube.transform.LookAt(cur, Vector3.right);
			

			//var relative : Vector3 = transform.InverseTransformPoint(lastHit.point);
			//var angle : float = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
			//playerCube.transform.Rotate (0, angle, 0);
			
			//var at : Vector3;
			//at  = lastHit.point;
			//playerCube.transform.LookAt(lastHit.point);
			//playerCube.transform.rotation.x = 0.0f;

		}
        //Debug.Log(lastHit.point.x.ToString() + "," + lastHit.point.y.ToString() + "," + lastHit.point.z.ToString());
        
    }

    
}

/*
function OnMouseDown () {
    var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    var hit : RaycastHit;
    
    var layerMask = 1 << 8;
    //layerMask = ~layerMask;
    
    if(Physics.Raycast(ray, hit, Mathf.Infinity,layerMask) &&Input.GetMouseButton(0))
    {
    	if(hit.collider.gameObject.tag == "PLANE"){
	        // to represent that the picked object is 'selected', we add some gray
	       // hit.collider.gameObject.renderer.material.color += Color.grey;
	        lastHit = hit;
	        lastUpdateWasAHit = true;
        
        	playerCube.transform.position.x = lastHit.point.x;
			playerCube.transform.position.z = lastHit.point.z;
		}
        //Debug.Log(lastHit.point.x.ToString() + "," + lastHit.point.y.ToString() + "," + lastHit.point.z.ToString());
        
    }
}
*/