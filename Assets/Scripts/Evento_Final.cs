using UnityEngine;
using System.Collections;

public class Evento_Final : MonoBehaviour {
    public Transform dragaoPrefab;
    public Transform dragaoStart;
    public Transform dragaoEnd;
    public CameraRotation cameraRotation;
    public Light luz;
    public Portal portal;

    private DragaoScript dragao;
    private MovimentoHumanoide player;
    private float cronometro;
    private bool comecou;

    /* O Evento começa aqui, quando o jogador colide com o
     * ativador
     * */
    void OnTriggerEnter(Collider other) {
        if (!comecou) {
            comecou = true;
            player = other.GetComponent<MovimentoHumanoide>();
            player.rigidbody.isKinematic = false;
            player.rigidbody.constraints = RigidbodyConstraints.None;
            player.rigidbody.mass = 0.1f;
            player.Habilitado = false;

            Transform dragaoObject = (Transform)Instantiate(dragaoPrefab, dragaoStart.position, dragaoStart.rotation);
            dragao = dragaoObject.GetComponent<DragaoScript>();
            dragao.UsarFogo();
            dragao.transform.RotateAround(dragao.transform.position, Vector3.up, -90);
            dragaoStart.position = new Vector3(dragaoStart.position.x, dragaoStart.position.y, player.transform.position.z);
            dragaoEnd.position = new Vector3(dragaoEnd.position.x, dragaoEnd.position.y, player.transform.position.z);
        }
    }

    void Update() {
        if (comecou) {
            cronometro += Time.deltaTime;

            // Camera seguindo o dragão
            if (cronometro < 5) {
                dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
                Camera.main.transform.position = dragao.transform.position - new Vector3(5.5f, -1.3f, 1);
                Camera.main.transform.LookAt(dragao.transform);
            } else {
                cameraRotation.ResetCamera();
                player.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                player.rigidbody.velocity = Vector3.zero;
                player.rigidbody.angularVelocity = Vector3.zero;
                portal.Teleportar(player.transform);
                player.transform.eulerAngles = new Vector3(0, 180, 0);

                Camera.main.transform.position = player.transform.position + Vector3.forward * -0.8f;
                Camera.main.transform.LookAt(player.transform);
                luz.intensity = 0.4f;

                Destroy(dragao.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
