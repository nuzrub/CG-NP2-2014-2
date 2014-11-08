using UnityEngine;
using System.Collections;

public class MovimentoHumanoide : MonoBehaviour {

    private CharacterController controller;
    private float movementSpeed = 2f;
    private float rotationSpeed = 180f;
    private float gravityAccel = -0.25f;
    private float jumpHeight = 0.10f;
    private float jumpInterval = 0.4f;

    private float verticalVelocity;
    private float lastJump;

	void Start () {
        controller = GetComponent<CharacterController>();
        verticalVelocity = 0f;

        jumpInterval += -Mathf.Sqrt(-2 * gravityAccel * jumpHeight) / gravityAccel;
        lastJump = -jumpInterval;
	}
	

	void Update () {
        Rotacionar();
        Movimentar();
	}

    private void Rotacionar() {
        float rotation = rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }
    private void Movimentar() {
        float movement = movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

        if (controller.isGrounded) {
            if (Input.GetButton("Jump") && verticalVelocity < 0.1f && (Time.time > (lastJump + jumpInterval))) {
                verticalVelocity = Mathf.Sqrt(-2 * gravityAccel * jumpHeight) / 2f;
                lastJump = Time.time;
            } else {
                verticalVelocity = 0;
            }
        } else {
            verticalVelocity += gravityAccel * Time.deltaTime;
        }


        if (movement != 0) {
            animation.CrossFade("run");
        } else {
            animation.CrossFade("idle");
        }

        
        controller.Move(
            transform.forward * movement + 
            transform.up * verticalVelocity);
    }
}
