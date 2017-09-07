using UnityEngine;
using System.Collections;

public class TreeSpawner : MonoBehaviour {
	
	public GameObject treePrefab;
	public int minimumNumberOfTrees = 5;
	public int maximumNumberOfTrees = 15;

	private int mapScale = 100;

	// Use this for initialization
	void Start () {
		int numberOfTrees = Random.Range (minimumNumberOfTrees, (maximumNumberOfTrees + 1));

		for (int i = 0; i < numberOfTrees; i++) {
			SpawnRandomTree ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void SpawnRandomTree () {
		float x = Random.Range (-50f * mapScale, 50f * mapScale);
		float z = Random.Range (-5f * mapScale, 5f * mapScale);

		GameObject newTree = Instantiate (treePrefab);
		newTree.transform.parent = transform;
		newTree.transform.localPosition = new Vector3 (x, 0, z);
	}
}
