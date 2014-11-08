using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    Transform respawnPoint;

    void Start() {
        respawnPoint = transform.GetChild(0);
    }

    void OnTriggerEnter(Collider other) {
        other.transform.position = respawnPoint.position;
        other.transform.rotation = respawnPoint.rotation;
    }
}
