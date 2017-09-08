using UnityEngine;
using System.Collections;

public class FrogCharacterController : MonoBehaviour {

	public float[] jumpSpeed = { 300, 700, 1000 };
	public float jumpElevationAngleDeg = 45.0f;

	private Rigidbody myRigidBody;
	private Camera myCamera;
	private int collisionCount = 0;
	private int hops = 0;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();
		myCamera = GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (collisionCount > 0) {
			hops = 0;
		}
		if (GvrViewer.Instance.Triggered) { 
			hops++;
			if (hops < jumpSpeed.Length) {
				Jump ();
			}
		}
	}

	void OnCollisionEnter () {
		collisionCount++;
	}

	void OnCollisionExit () {
		collisionCount--;
	}

	private void Jump () {
		Vector3 projectedLookDirection = Vector3.ProjectOnPlane (myCamera.transform.forward, Vector3.up);
		float radiansToRotate = Mathf.Deg2Rad * jumpElevationAngleDeg;
		Vector3 unnormalizedJumpDirection = Vector3.RotateTowards (projectedLookDirection, Vector3.up, radiansToRotate, 0);
		Vector3 jumpDirection = unnormalizedJumpDirection.normalized * jumpSpeed[hops];

		myRigidBody.AddForce(jumpDirection, ForceMode.VelocityChange);

		if (myRigidBody.velocity.magnitude > jumpSpeed[hops]) {
			myRigidBody.velocity = myRigidBody.velocity.normalized * jumpSpeed[hops];
		}
	}
}
	