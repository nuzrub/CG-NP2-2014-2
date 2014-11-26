using UnityEngine;
using System.Collections;

public class MovimentoHumanoide : MonoBehaviour {

    public bool Habilitado = true;
    private float movementSpeed = 2f;
    private float rotationSpeed = 180f;
    private float jumpHeight = 2f;
    private float jumpInterval = 0.7f;
    private float lastJump;

    void Start() {
		//Garante que o personagem podera pular apos o termino do pulo anterior.
        jumpInterval += -Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) / Physics.gravity.y;
        lastJump = -jumpInterval;
    }
	

	void FixedUpdate () {
        Rotacionar();
        Movimentar();
	}

	//Gira o personagem em torno do proprio eixo.
    private void Rotacionar() {
        if (Habilitado) {
            float rotation = rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            transform.Rotate(Vector3.up, rotation);
        }
    }
	//Movimenta o personagem para frente e garante a habilidade de pular.
    private void Movimentar() {
        Vector3 verticalSpeed = Vector3.zero;
        float forwardSpeed = movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

        if (Input.GetButton("Jump")) {
            if (isGrounded() && Time.time > lastJump) {
                verticalSpeed += transform.up * JumpSpeed();
                lastJump += jumpInterval;
            }
        }

        if (!Habilitado) {
            forwardSpeed = 0;
            verticalSpeed = Vector3.zero;
        }

        rigidbody.velocity = rigidbody.velocity + verticalSpeed;
        rigidbody.MovePosition(rigidbody.position + transform.forward * forwardSpeed);

		//Modifica a animacao de correr durante o pulo para "idle", em espera.
        if (!isGrounded()) {
            animation.CrossFade("idle");
        } else if (forwardSpeed != 0) {
            animation.CrossFade("run");
        } else {
            animation.CrossFade("idle");
        }
    }

	//Metodo para verificar se o personagem esta no chao/plataforma.
    private bool isGrounded() {
        return Physics.Raycast(
            new Ray(transform.position, Vector3.down),
            transform.localScale.y * 1.02f,
            LayerMask.GetMask("Floor", "Floor Movel"));
    }
	//Instancia a velocidade do pulo.
    private float JumpSpeed() {
        return Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) / 2f;
    }
}
