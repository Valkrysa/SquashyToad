using UnityEngine;
using System.Collections;

public class FrogCharacterController : MonoBehaviour {

	public float jumpSpeed = 500.0f;
	public float jumpElevationAngleDeg = 45.0f;
	public float maxSpeed = 500.0f;
	public float jumpGroundClearance = 100.0f;

	private Rigidbody myRigidBody;
	private Camera myCamera;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();
		myCamera = GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrViewer.Instance.Triggered) {
			Jump ();
		}
	}

	private void Jump () {
		if (Physics.Raycast(transform.position, -transform.up, jumpGroundClearance)) {
			Vector3 projectedLookDirection = Vector3.ProjectOnPlane (myCamera.transform.forward, Vector3.up);
			float radiansToRotate = Mathf.Deg2Rad * jumpElevationAngleDeg;
			Vector3 unnormalizedJumpDirection = Vector3.RotateTowards (projectedLookDirection, Vector3.up, radiansToRotate, 0);
			Vector3 jumpDirection = unnormalizedJumpDirection.normalized * jumpSpeed;

			myRigidBody.AddForce(jumpDirection, ForceMode.VelocityChange);

			if (myRigidBody.velocity.magnitude > maxSpeed) {
				myRigidBody.velocity = myRigidBody.velocity.normalized * maxSpeed;
			}
		}
	}
}
	