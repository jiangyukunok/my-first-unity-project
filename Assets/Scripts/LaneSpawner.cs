using UnityEngine;
using System.Collections;

enum LaneType {Safe, Danger};

public class LaneSpawner : MonoBehaviour {
	public GameObject[] safeLanePrefabs;
	public GameObject[] dangerousPrefabs;
	LaneType lastLaneType = LaneType.Safe;
	// Use this for initialization
	void Start () {
		int offset = 0;
		while (offset < 50000) {
			CreateRandomLane (offset);
			offset += 1000;
		}
	}
		
	void CreateRandomLane(float offset){
		GameObject lane;
		if (lastLaneType == LaneType.Safe) {
			if (Random.value < 0.5) {
				lane = InstantiateRandomLane (safeLanePrefabs);
			} else {
				lane = InstantiateRandomLane (dangerousPrefabs);
				lastLaneType = LaneType.Danger;
			}
		} else {
			lane = InstantiateRandomLane (safeLanePrefabs);
			lastLaneType = LaneType.Safe;
		}
		lane.transform.SetParent (transform, false);//.parent = transform;
		lane.transform.Translate (0, 0, offset);
	}

	GameObject InstantiateRandomLane(GameObject[] lanes){
		int laneIndex = Random.Range (0, lanes.Length);
		return Instantiate (lanes [laneIndex]);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
