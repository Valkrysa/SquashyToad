using UnityEngine;
using System.Collections;

public class VehicleMovement : MonoBehaviour {

	public float velocity = 1000.0f;

	private Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		// transform.Translate (-velocity * Time.deltaTime, 0, 0);
	}

	void FixedUpdate () {
		myRigidBody.MovePosition (transform.position - (transform.right * velocity) * Time.deltaTime);
	}
}
