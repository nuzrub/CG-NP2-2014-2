using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

    public Vector3 initialPos;
    public Quaternion initialRot;
	public int speed;

	//Metodo para iniciar a rotacao da camera.
    void Start() {
        initialPos = transform.localPosition;
        initialRot = transform.localRotation;
    }

	//Metodo que ira girar a camera em torno do personagem, e olhando para o personagem.
	void Update () {
        Vector3 pivot = transform.parent.position;

		if (Input.GetKey (KeyCode.Z)) {
            transform.RotateAround(pivot, Vector3.up, speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.X)) {
            transform.RotateAround(pivot, Vector3.down, speed * Time.deltaTime);
		}

        if (Input.GetKey(KeyCode.R)) {
            ResetCamera();
        }
	}

    public void ResetCamera() {
        transform.localPosition = initialPos;
        transform.localRotation = initialRot;
    }
}