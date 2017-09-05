using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public Vector3 jumpVector;

	private Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			myRigidBody.AddForce(jumpVector, ForceMode.VelocityChange);
		}
	}

	private void Jump () {
		
	}
}
