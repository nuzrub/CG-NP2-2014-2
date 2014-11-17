using UnityEngine;
using System.Collections;

public class MoverPlataforma : MonoBehaviour {

    public Transform start;
    public Transform end;
    public float duration = 1f;
    private float cronometro;
    private bool voltando;

	void Start () {
        transform.position = start.position;
        cronometro = 0;
        voltando = false;
	}
	

	void Update () {
        cronometro += Time.deltaTime;

        if (voltando) {
            rigidbody.MovePosition(Vector3.Lerp(end.position, start.position, cronometro / duration));
        } else {
            rigidbody.MovePosition(Vector3.Lerp(start.position, end.position, cronometro / duration));
        }

        if (cronometro > duration) {
            cronometro -= duration;
            voltando = !voltando;
        }
	}
}
