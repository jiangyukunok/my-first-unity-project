using UnityEngine;
using System.Collections;

public class FrogMovement : MonoBehaviour {
	public float jumpElevationInDegrees = 45;
	public float jumpSpeedInMPS = 5;
	public float jumpSpeedTolerance = 5;
	public float jumpGroundClearance = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool isOnGround = Physics.Raycast (transform.position, -transform.up, jumpGroundClearance);
		//Debug.DrawRay (transform.position, -transform.up * jumpGroundClearance, Color.yellow);
		var speed = GetComponent<Rigidbody> ().velocity.magnitude;
		bool isNearStationary = speed < jumpSpeedTolerance;
		if (GvrViewer.Instance.Triggered && isOnGround && isNearStationary) {
			Camera camera = GetComponentInChildren<Camera> ();
			//Debug.DrawRay (transform.position, camera.transform.forward, Color.red);
			var projectLookDirection = Vector3.ProjectOnPlane (camera.transform.forward, Vector3.up);
			//Debug.DrawRay (transform.position, projectLookDirection, Color.blue);
			var radianToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
			var unnormalizedJumpDirection = Vector3.RotateTowards (projectLookDirection, Vector3.up, radianToRotate, 0);
			var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInMPS;
			//Debug.DrawRay (transform.position, jumpVector, Color.green);
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
		}
	}
}
