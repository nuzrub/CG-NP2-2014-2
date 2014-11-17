using UnityEngine;
using System.Collections;

public class MovimentoHumanoide : MonoBehaviour {

    private float movementSpeed = 2f;
    private float rotationSpeed = 180f;
    private float jumpHeight = 2f;
    private float jumpInterval = 0.4f;
    private float lastJump;

    void Start() {
        jumpInterval += -Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) / Physics.gravity.y;
        lastJump = -jumpInterval;
    }
	

	void FixedUpdate () {
        Rotacionar();
        Movimentar();
	}

    private void Rotacionar() {
        float rotation = rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }
    private void Movimentar() {
        Vector3 verticalSpeed = Vector3.zero;
        float forwardSpeed = movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

        if (Input.GetButton("Jump")) {
            if (isGrounded() && Time.time > lastJump) {
                verticalSpeed += transform.up * JumpSpeed();
                lastJump += jumpInterval;
            }
        }

        rigidbody.velocity = rigidbody.velocity + verticalSpeed;
        rigidbody.MovePosition(rigidbody.position + transform.forward * forwardSpeed);
        

        if (rigidbody.velocity != Vector3.zero || forwardSpeed != 0) {
            animation.CrossFade("run");
        } else {
            animation.CrossFade("idle");
        }
    }

    private bool isGrounded() {
        return Physics.Raycast(
            new Ray(transform.position, Vector3.down),
            transform.localScale.y * 1.02f,
            LayerMask.GetMask("Floor"));
    }
    private float JumpSpeed() {
        return Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) / 2f;
    }
}
