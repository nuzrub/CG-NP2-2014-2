using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	public int speed;

	void Update () {
		if (Input.GetKey (KeyCode.Z)) {
			transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.X)) {
			transform.RotateAround(Vector3.zero, Vector3.down, speed * Time.deltaTime);
		}
	}
}