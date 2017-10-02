using UnityEngine;
using System.Collections;

public class FrogMovement : MonoBehaviour {
	float jumpElevationInDegrees = 45;
	float[] jumpSpeedInCMPS = {300, 400, 0};
	//public float jumpSpeedTolerance = 5;
	//public float jumpGroundClearance = 250;

	public int collisionCount = 0;
	public int hopCount = 0;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter() {
		collisionCount++;
	}

	void OnCollisionExit() {
		collisionCount--;
	}

	// Update is called once per frame
	void Update () {
		bool isOnGround = collisionCount > 0;//Physics.Raycast (transform.position, -transform.up, jumpGroundClearance);
		//Debug.DrawRay (transform.position, -transform.up * jumpGroundClearance, Color.yellow);
		//var speed = GetComponent<Rigidbody> ().velocity.magnitude;
		//bool isNearStationary = speed < jumpSpeedTolerance;

		if (isOnGround) {
			hopCount = 0;
		}

		if (GvrViewer.Instance.Triggered && hopCount < jumpSpeedInCMPS.Length) {// && isOnGround && isNearStationary) {
			Camera camera = GetComponentInChildren<Camera> ();
			//Debug.DrawRay (transform.position, camera.transform.forward, Color.red);
			var projectLookDirection = Vector3.ProjectOnPlane (camera.transform.forward, Vector3.up);
			//Debug.DrawRay (transform.position, projectLookDirection, Color.blue);
			var radianToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
			var unnormalizedJumpDirection = Vector3.RotateTowards (projectLookDirection, Vector3.up, radianToRotate, 0);
			var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInCMPS[hopCount];
			//Debug.DrawRay (transform.position, jumpVector, Color.green);
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
			hopCount++;
		}
	}
}
