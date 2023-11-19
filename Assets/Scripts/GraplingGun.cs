using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingGun : MonoBehaviour
{
   private LineRenderer lr;
   private Vector3 grapplePoint;
   public LayerMask whatIsGrappleable;
   public Transform gunTip , camera, player;
   public float maxDistance = 100.0f;
   private SpringJoint joint;
   public float anchorx = 1.0f;
   public float anchory = 1.0f;
   public float anchorz = 1.0f;
   public float Tolerance = 1.0f;
   public float Spring = 4.5f;
   public bool AutoConfig = true;
   private bool active = false;
   
   
   
   void Awake(){
	   lr = GetComponent<LineRenderer>();
   }
   
  
  
  
  
   
   void Update()
   {
	   
	   
	   
	if(Input.touchCount > 0 && FixedButton.PublicPress == false){
		StartGrapple();
		Debug.Log("down");
	}
	else if(FixedButton.PublicPress == true){
		StopGrapple();
	}
   }
   
   
   void LateUpdate()
   {
	   DrawRope();
   }
   
   
   
   
     void DrawLine(Vector3 start, Vector3 end, float duration)
         {
             GameObject myLine = new GameObject();
             myLine.transform.position = start;
             myLine.AddComponent<LineRenderer>();
             LineRenderer lr = myLine.GetComponent<LineRenderer>();
            // lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
             lr.startColor = Color.red;
             lr.endColor = Color.red;
             lr.SetWidth(0.1f, 0.1f);
             lr.SetPosition(0, start);
             lr.SetPosition(1, end);
             GameObject.Destroy(myLine, duration);
         }
		 
		 
		 
   
   void StartGrapple()
   {
	  Debug.Log("line");
	 // DrawLine(camera.position,camera.position*100, 100.0f);
	 Debug.DrawRay(camera.position, camera.forward * 1000, Color.green, 5.0f);
	  RaycastHit hit;
	  
	  for(int i=0;i<Input.touchCount;i++){
	    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
		//camera.position, camera.forward, out hit, maxDistance,whatIsGrappleable
	  if(Physics.Raycast(ray, out hit, maxDistance, whatIsGrappleable)){
		  
		  if(active == false){
		   Debug.Log("line hit");
		  grapplePoint = hit.point;
		  joint = player.gameObject.AddComponent<SpringJoint>();
		  joint.autoConfigureConnectedAnchor = AutoConfig;
		  joint.connectedAnchor = grapplePoint;
		  
		  float distanceFromPoint = Vector3.Distance(a: player.position, b: grapplePoint);
		  
		  
		  joint.maxDistance = distanceFromPoint * 1.5f;
		  joint.minDistance = distanceFromPoint * 0.25f;
		  
		  joint.spring = Spring;
		  joint.damper = 7.0f;
		  joint.massScale = 4.5f;
		  joint.tolerance = Tolerance;  //larger = less stiff, tolerate more error
		  joint.anchor = new Vector3(anchorx,anchory,anchorz);
		
		  lr.positionCount = 2;
		  
		  player.GetComponent<Rigidbody>().AddForce(Vector3.forward*1000.0f);
	  }
	  }	 
   }	  
	  
	  
   }
   
   void StopGrapple()
   {
	 lr.positionCount = 0;
	 Debug.Log("attempt kill joint");
	 while(player.GetComponent<SpringJoint>() != null){
	 Destroy(player.GetComponent<SpringJoint>());
	 }
   }
   
   void DrawRope()
   {
	   if(!joint) return;
	   
	   
	   lr.SetPosition(0,gunTip.position);
	   lr.SetPosition(1,grapplePoint);
   }
   
   
   
   
   
}
