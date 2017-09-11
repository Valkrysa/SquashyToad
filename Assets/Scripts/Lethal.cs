using UnityEngine;
using System.Collections;

public class Lethal : MonoBehaviour {

	private Death deathComponent;

	// Use this for initialization
	void Start () {
		deathComponent = FindObjectOfType<Death> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision other) {
		deathComponent.OnDeath ();
		/* if (other.gameObject.GetComponent<Death>()) {
			Canvas gameOverCanvas = other.gameObject.GetComponentInChildren<Canvas> (true);
			if (gameOverCanvas) {
				gameOverCanvas.gameObject.SetActive (true);
			}
		} */
	}
}
