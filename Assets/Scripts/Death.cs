using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	public GameObject UICanvas;
	public GameObject Reticle;

	public void OnDeath(){
		UICanvas.SetActive (true);
		Reticle.SetActive (true);
		GetComponent<Rigidbody> ().isKinematic = true;
	}
}
