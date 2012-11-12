#pragma strict

var lastHit : RaycastHit;
var layerMask = 1 << 8;

function Update ()
{
    var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    var hit : RaycastHit;
    if(Physics.Raycast (ray, hit, Mathf.Infinity, layerMask))
    {
        lastHit = hit;  
        this.transform.position.x =  lastHit.point.x; 
        this.transform.position.y =  lastHit.point.y;
        this.transform.position.z =  lastHit.point.z;
//        Debug.Log("pilayerMaskpck : " + lastHit.point.x.ToString() + " " +  lastHit.point.y.ToString() + " " +lastHit.point.z.ToString());
  	}
}