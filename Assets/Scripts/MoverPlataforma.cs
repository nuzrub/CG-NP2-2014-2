using UnityEngine;
using System.Collections;

public class MoverPlataforma : MonoBehaviour {

    public Transform start;
    public Transform end;
    public float duration = 1f;
    private float cronometro;
    private bool voltando;

	void Start () {
        transform.position = end.position;
        cronometro = 0;
        voltando = false;
	}
	

	void Update () {
        cronometro += Time.deltaTime;

        /*if (voltando) {
            rigidbody.MovePosition(Vector3.Lerp(end.position, start.position, cronometro / duration));
        } else {
            rigidbody.MovePosition(Vector3.Lerp(start.position, end.position, cronometro / duration));
        }*/

		// Inicia o movimento da plataforma para a direita se a variavel "voltando" for "false" e para a esquerda se for "true".
        if (voltando) {
            rigidbody.velocity = (end.position - start.position) / duration;
        } else {
            rigidbody.velocity = (start.position - end.position) / duration;
        }

        if (cronometro > duration) {
            cronometro -= duration;
            voltando = !voltando;

            if (voltando) {
                rigidbody.velocity = (start.position - end.position) / duration;
            } else {
                rigidbody.velocity = (end.position - start.position) / duration;
            }
        }
	}
}
