using UnityEngine;
using System.Collections;

public class Evento_Yandre : MonoBehaviour {

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

	/*Classe para o evento do Yandre. */


	//Metodo que iniciara o evento do Yandre, quando o jogador colide com o ativador. */
    void OnTriggerEnter(Collider other) {
        if (!comecou) {
            comecou = true;
            player = other.GetComponent<MovimentoHumanoide>();
            player.Habilitado = false;

			//Posicao e inicial e final fazendo o caminho q ele ira se mover, 
			//iniciando o audio e lancando o fogo pela boca no final do evento.

            Transform dragaoObject = (Transform)Instantiate(dragaoPrefab, dragaoStart.position, dragaoStart.rotation);
            dragao = dragaoObject.GetComponent<DragaoScript>();
            dragao.Voar();
            dragao.transform.RotateAround(dragao.transform.position, Vector3.up, 225);

            audio.PlayOneShot(audio.clip);
            comecouSom2 = false;

            BGM_Controller.PlayEmergency();
        }
    }

    void Update() {
        if (comecou) {
            cronometro += Time.deltaTime;

			//Camera olhando para o dragao durante o evento.
            if (cronometro < 3.5f) {
                dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
                Camera.main.transform.position = dragao.transform.position - new Vector3(1.5f, -2f, 6f);
                Camera.main.transform.LookAt(dragao.transform);
            } else if (cronometro < 6) {
                dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
                Camera.main.transform.position = dragao.transform.position - new Vector3(1.5f, -2f, 6f);
                Camera.main.transform.LookAt(dragao.transform);
                dragao.UsarFogo();
                if (comecouSom2 == false) {
                    audio.PlayOneShot(som2);
                    comecouSom2 = true;
                }

				//Camera olhando para o player apos o evento do dragao.
            } else if (cronometro < 10) {
                Camera.main.transform.position = player.transform.position - new Vector3(0.5f, -0.1f, -0.3f);
                Camera.main.transform.LookAt(player.transform);

				//Camera retorna ao ponto inicial para o jogador continuar o jogo.
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
