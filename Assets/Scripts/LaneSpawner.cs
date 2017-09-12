using UnityEngine;
using System.Collections;

enum LaneType { Safe, Danger };

public class LaneSpawner : MonoBehaviour {

	public GameObject[] dangerousLanes;
	public GameObject[] safeLanes;
	public int numberOfLanes = 10;
	public float safeLaneRunProbability = 0.2f;

	private int laneWidth = 1000;
	private LaneType lastLaneType = LaneType.Safe;

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
		GameObject lane;

		if (lastLaneType == LaneType.Safe) {
			if (Random.value <= safeLaneRunProbability) {
				lane = InstantiateRandomLane (safeLanes);
				lastLaneType = LaneType.Safe;
			} else {
				lane = InstantiateRandomLane (dangerousLanes);
				lastLaneType = LaneType.Danger;
			}
		} else {
			lane = InstantiateRandomLane (safeLanes);
			lastLaneType = LaneType.Safe;
		}

		lane.transform.SetParent (transform, false);
		lane.transform.Translate (0, 0, offset);
	}

	private GameObject InstantiateRandomLane(GameObject[] lanes) {
		int laneIndex = Random.Range (0, lanes.Length);
		return Instantiate (lanes [laneIndex]);
	}
}
