using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
 
public class FPSController : MonoBehaviour {
 
	public float speed = 10.0f;
	public float jumpHeight = 10.0f;
	public bool grounded = true;
	public Transform cam;
	public float maxVelocityChange = 3.0f;
	public float jetpackPower = 10.0f;
	
	public void Start () {}
	
	public void FixedUpdate () {
		//check if the player is grounded or not
		if (grounded) {
			
			//figure out where the current mouselook is looking
			Vector3 targetVelocity = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		
			//point that input to the current camera transform
			targetVelocity = cam.transform.TransformDirection (targetVelocity);
			
			//get the current rigidbody velocity
			Vector3 velocity = rigidbody.velocity;
			
			//add velocity in the direction of movement
			Vector3 velocityChange = (targetVelocity - velocity);
			
			//set up the new direction vector based on clamped velocity
			velocityChange.x = Mathf.Clamp (velocity.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = Mathf.Clamp (velocityChange.y, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
			
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
		}
		
		//did we hit jump?
		if(Input.GetButtonDown("Jump") && grounded) {
			rigidbody.AddForce(transform.up*jumpHeight);
			grounded = false;
		}
		
		if(Input.GetButtonDown("Jump") && !grounded) {
			rigidbody.AddForce(transform.up*jetpackPower);
		}
	}
	
	public void OnCollisionStay(Collision collision) {
		if(collision.transform.tag != "Not Ground") {
			grounded = true;
		}
	}
}