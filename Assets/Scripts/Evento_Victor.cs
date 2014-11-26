using UnityEngine;
using System.Collections;

public class Evento_Victor : MonoBehaviour {

    public GameObject eventofinal;
	public Transform dragaoPrefab;
	public Transform dragaoStart;
	public Transform dragaoEnd;
    public Transform playerEnd;
	public CameraRotation cameraRotation;
	public Light luz;
    public Rigidbody[] pilares;
	public GameObject dragaoDormindo;
    public AudioClip som2;

	private DragaoScript dragao;
	private MovimentoHumanoide player;
	private float cronometro;
	private bool comecou;
    private bool comecouSom2;
	
	/* O Evento começa aqui, quando o jogador colide com o
     * ativador, o dragao que estava dormindo acorda e 
     * */
	void OnTriggerEnter(Collider other) {
		if (!comecou) {
			Destroy(dragaoDormindo);
			comecou = true;
			player = other.GetComponent<MovimentoHumanoide>();
            player.transform.LookAt(playerEnd);
            player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);
            player.animation.CrossFade("run");
            player.enabled = false;
			
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
			
			// Camera seguindo o dragão.
			if (cronometro < 1) {
				dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
				Camera.main.transform.position = dragao.transform.position - new Vector3(-7.5f, 0.3f, 0);
				Camera.main.transform.LookAt(dragao.transform);

				//Adiciona o efeito para empurra os pilares e o tecido.
                foreach (var rb in pilares) {
                    rb.AddExplosionForce(-200f * Time.deltaTime, dragao.transform.position, 65f);
                }

				// Camera olhando para o dragao enquanto ele levanta voo lancando o efeito de fogo.
            }else if (cronometro < 6) {
                dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
                player.transform.position = Vector3.Lerp(player.transform.position, playerEnd.position, (cronometro - 1) / 15f);
                Camera.main.transform.position = dragao.transform.position;
                Camera.main.transform.position -= Vector3.Lerp(new Vector3(-7.5f, 0.3f, 0), new Vector3(-12.5f, 4.0f, 0), (cronometro - 1) / 5f);
                Camera.main.transform.LookAt(dragao.transform);

				//Adiciona o efeito para empurra os pilares e o tecido.
                foreach (var rb in pilares) {
                    rb.AddExplosionForce(-200f * Time.deltaTime, dragao.transform.position, 65f);
                }
                dragao.UsarFogo();
                if (comecouSom2 == false) {
                    audio.PlayOneShot(som2);
                    comecouSom2 = true;
                }
				// Voltando pra câmera normal e destruindo o evento e dragão.
			} else {

				//Elimina o dragao e este evento no fim da cena e ativa o evento final.
				Destroy(dragao.gameObject);
				//Destroy(player1.transform.GetChild(0).gameObject);
				//Destroy(player1.transform.GetChild(1).gameObject);
				Destroy(this.gameObject);
                cameraRotation.ResetCamera();
                player.enabled = true;
                eventofinal.SetActive(true);
                BGM_Controller.PlayMoonshift();
			}
		}
	}
}
