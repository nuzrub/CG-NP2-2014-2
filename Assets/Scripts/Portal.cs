using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	Transform smokePoint;
	Transform respawnPoint;
	public GameObject smoke;
	void Start() {
		respawnPoint = transform.GetChild(0);
		smokePoint = transform.GetChild (1);
	}
	
	void OnTriggerEnter(Collider other) {
		Instantiate(smoke,smokePoint.position,smokePoint.rotation);
		other.transform.position = respawnPoint.position;
		other.transform.rotation = respawnPoint.rotation;
	}
}
