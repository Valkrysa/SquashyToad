using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	private GameObject gameOverCanvas;
	private GameObject reticule;

	// Use this for initialization
	void Start () {
		gameOverCanvas = GetComponentInChildren<Canvas> (true).gameObject;
		reticule = GetComponentInChildren<GvrReticle> (true).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDeath () {
		GetComponent<Rigidbody> ().isKinematic = true;
		reticule.SetActive (true);
		gameOverCanvas.SetActive (true);
	}
}
