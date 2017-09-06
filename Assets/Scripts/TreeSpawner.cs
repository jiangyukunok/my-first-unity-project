using UnityEngine;
using System.Collections;

public class TreeSpawner : MonoBehaviour {
	public GameObject TreePrefab;
	// Use this for initialization
	void Start () {
		CreateTree ();
		CreateTree ();
		CreateTree ();
	}

	void CreateTree(){
		var tree = Instantiate (TreePrefab);
		tree.transform.parent = transform;
		//tree.transform.Translate(Random.Range(-50,50), 0, Random.Range(-5,5));
		tree.transform.localPosition = new Vector3(Random.Range(-50,50), 0, Random.Range(-5,5));
	}

	// Update is called once per frame
	void Update () {
	
	}
}
