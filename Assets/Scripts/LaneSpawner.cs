using UnityEngine;
using System.Collections;

public class LaneSpawner : MonoBehaviour {

	public GameObject[] lanePrefabs;
	public int numberOfLanes = 10;

	private int laneWidth = 1000;

	// Use this for initialization
	void Start () {
		float offset = 0f;
		while (offset < (numberOfLanes * laneWidth)) {
			CreateRandomLane(offset);

			offset += laneWidth;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CreateRandomLane (float offset) {
		int laneIndex = Random.Range (0, lanePrefabs.Length);

		GameObject lane = Instantiate (lanePrefabs [laneIndex]);
		lane.transform.SetParent (transform, false);
		lane.transform.Translate (0, 0, offset);
	}
}
