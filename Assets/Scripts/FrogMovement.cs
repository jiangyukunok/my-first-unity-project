using UnityEngine;
using System.Collections;

public class FrogMovement : MonoBehaviour {
	public Vector3 jumpVector;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, jumpVector, Color.red);
		var projectJumpVector = Vector3.ProjectOnPlane (jumpVector, Vector3.up);
		Debug.DrawRay (transform.position, projectJumpVector, Color.blue);
		var radianToRotate = Mathf.Deg2Rad * 75;
		var rotatedJumpVector = Vector3.RotateTowards (projectJumpVector, Vector3.up, radianToRotate, 0);
		Debug.DrawRay (transform.position, rotatedJumpVector.normalized, Color.green);
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
		}
	}
}
