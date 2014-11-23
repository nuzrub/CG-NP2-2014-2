using UnityEngine;
using System.Collections;

public class Destruidor : MonoBehaviour {

	void Update () {
        if (transform.position.y < -5) {
            Destroy(this.gameObject);
        }
	}
}
