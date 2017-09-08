using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] spawnChoices;
	public float meanSpawnTime = 4f;
	public float minimumSpawnTime = 2f;

	private float nextSpawnTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTime) {
			Spawn ();
			nextSpawnTime = Time.time + minimumSpawnTime + ((-Mathf.Log (Random.value)) * meanSpawnTime);
		}
	}

	private void Spawn () {
		int choiceIndex = Random.Range (0, spawnChoices.Length);

		Instantiate (spawnChoices [choiceIndex], transform.position, transform.rotation, transform);
	}
}
