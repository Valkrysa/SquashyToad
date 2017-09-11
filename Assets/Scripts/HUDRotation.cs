using UnityEngine;
using System.Collections;

public class HUDRotation : MonoBehaviour {

	private Camera playerCamera;

	// Use this for initialization
	void Start () {
		playerCamera = transform.parent.GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 projectedLookDirection = Vector3.ProjectOnPlane (playerCamera.transform.forward, Vector3.up);
		transform.rotation = Quaternion.LookRotation (projectedLookDirection);
	}
}
