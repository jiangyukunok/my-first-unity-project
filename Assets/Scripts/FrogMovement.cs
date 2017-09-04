using UnityEngine;
using System.Collections;

public class FrogMovement : MonoBehaviour {
	public float jumpElevationInDegrees = 45;
	public float jumpSpeedInMPS = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera camera = GetComponentInChildren<Camera> ();
		Debug.DrawRay (transform.position, camera.transform.forward, Color.red);
		var projectLookDirection = Vector3.ProjectOnPlane (camera.transform.forward, Vector3.up);
		Debug.DrawRay (transform.position, projectLookDirection, Color.blue);
		var radianToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
		var unnormalizedJumpDirection = Vector3.RotateTowards (projectLookDirection, Vector3.up, radianToRotate, 0);
		var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInMPS;
		Debug.DrawRay (transform.position, jumpVector, Color.green);
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
		}
	}
}
