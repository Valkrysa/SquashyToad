using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] spawnChoices;
	public float spawnFrequencyMin = 1f;
	public float spawnFrequencyMax = 4f;

	private float nextSpawnTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTime) {
			Spawn ();
			nextSpawnTime = Time.time + Random.Range(spawnFrequencyMin, spawnFrequencyMax);
		}
	}

	private void Spawn () {
		int choiceIndex = Random.Range (0, spawnChoices.Length);

		Instantiate (spawnChoices [choiceIndex], transform.position, transform.rotation, transform);
	}
}
