using UnityEngine;
using System.Collections;

public class Destruidor : MonoBehaviour {

	//Metodo para destruir GameObjects.
	void Update () {
        if (transform.position.y < -5) {
            Destroy(this.gameObject);
        }
	}
}
