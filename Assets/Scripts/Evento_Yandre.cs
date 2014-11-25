using UnityEngine;
using System.Collections;

public class Evento_Yandre : MonoBehaviour {

    public Transform dragaoPrefab;
    public Transform dragaoStart;
    public Transform dragaoEnd;
    public CameraRotation cameraRotation;
    public Light luz;

    private DragaoScript dragao;
    private MovimentoHumanoide player;
    private float cronometro;
    private bool comecou;

    void OnTriggerEnter(Collider other) {
        if (!comecou) {
            comecou = true;
            player = other.GetComponent<MovimentoHumanoide>();
            player.Habilitado = false;

            Transform dragaoObject = (Transform)Instantiate(dragaoPrefab, dragaoStart.position, dragaoStart.rotation);
            dragao = dragaoObject.GetComponent<DragaoScript>();
            dragao.Voar();
            dragao.transform.RotateAround(dragao.transform.position, Vector3.up, 225);

        }
    }

    void Update() {
        if (comecou) {
            cronometro += Time.deltaTime;

            if (cronometro < 3.5f) {
                dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
                Camera.main.transform.position = dragao.transform.position - new Vector3(1.5f, -2f, 6f);
                Camera.main.transform.LookAt(dragao.transform);
            } else if (cronometro < 6) {
                dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
                Camera.main.transform.position = dragao.transform.position - new Vector3(1.5f, -2f, 6f);
                Camera.main.transform.LookAt(dragao.transform);
                dragao.UsarFogo();
            } else if (cronometro < 10) {
                Camera.main.transform.position = player.transform.position - new Vector3(0.5f, -0.1f, -0.3f);
                Camera.main.transform.LookAt(player.transform);

            } else {
                cameraRotation.ResetCamera();
                player.Habilitado = true;
                Destroy(dragao.gameObject);
                Destroy(this.gameObject);
            }


        }
    }
}
