﻿using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject prefab;
	public float meanTime = 4; 
	public float minTime = 2;
	//public float spawnIntervalMin = 1;
	//public float spawnIntervalMax = 4;
	float nextSpawnTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTime) {
			Spawn ();
			nextSpawnTime = Time.time + minTime -Mathf.Log (Random.value) * meanTime;//Random.Range (spawnIntervalMin, spawnIntervalMax);
		}
	}

	void Spawn() {
		var instance = Instantiate (prefab);
		instance.transform.parent = transform;
		instance.transform.position = transform.position;
		instance.transform.rotation = transform.rotation;
	}
}
