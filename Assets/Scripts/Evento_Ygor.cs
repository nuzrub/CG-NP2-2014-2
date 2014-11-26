using UnityEngine;
using System.Collections;

public class Evento_Ygor : MonoBehaviour {

    public Transform dragaoPrefab;
    public Transform dragaoStart;
    public Transform dragaoEnd;
    public CameraRotation cameraRotation;
    public Light luz;
    public AudioClip som2;

    private DragaoScript dragao;
    private MovimentoHumanoide player;
    private float cronometro;
    private bool comecou;
    private bool comecouSom2;

    /* O Evento começa aqui, quando o jogador colide com o
     * ativador
     * */
    void OnTriggerEnter(Collider other) {
        if (!comecou) {
            comecou = true;
            player = other.GetComponent<MovimentoHumanoide>();
            player.Habilitado = false;

            Transform dragaoObject = (Transform)Instantiate(dragaoPrefab, dragaoStart.position, dragaoStart.rotation);
            dragao = dragaoObject.GetComponent<DragaoScript>();
            dragao.Voar();
            dragao.transform.RotateAround(dragao.transform.position, Vector3.up, 180);

            audio.PlayOneShot(audio.clip);
            comecouSom2 = false;
            BGM_Controller.PlayEmergency();
        }
    }

	void Update () {
        if (comecou) {
            cronometro += Time.deltaTime;

            // Camera seguindo o dragão
            if (cronometro < 3.5) {
                dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
                Camera.main.transform.position = dragao.transform.position - new Vector3(4.5f, 0.3f, 0);
                Camera.main.transform.LookAt(dragao.transform);
            } else if (cronometro < 6) {
                dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
                Camera.main.transform.position = dragao.transform.position - new Vector3(4.5f, 0.3f, 0);
                Camera.main.transform.LookAt(dragao.transform);
                dragao.UsarFogo();
                if (comecouSom2 == false) {
                    audio.PlayOneShot(som2);
                    comecouSom2 = true;
                }
                // Camera olhando pro player
            } else if (cronometro < 10) {
                Camera.main.transform.position = player.transform.position + new Vector3(1f, 0, 0);
                Camera.main.transform.LookAt(player.transform);

                // Voltando pra câmera normal e destruindo o evento e dragão.
            } else {
                cameraRotation.ResetCamera();
                player.Habilitado = true;
                Destroy(dragao.gameObject);
                BGM_Controller.PlayPlan();
                Destroy(this.gameObject);
            }
        }
	}
}
