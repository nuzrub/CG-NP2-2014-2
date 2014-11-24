using UnityEngine;
using System.Collections;

public class Evento_Final : MonoBehaviour {
	
	public Transform dragaoPrefab;
	public Transform dragaoStart;
	public Transform dragaoEnd;
	public CameraRotation cameraRotation;
	public Light luz;

	public GameObject player1;
	public GameObject dragaoDormindo;

	private DragaoScript dragao;
	private MovimentoHumanoide player;
	private float cronometro;
	private bool comecou;
	
	/* O Evento começa aqui, quando o jogador colide com o
     * ativador
     * */
	void OnTriggerEnter(Collider other) {
		if (!comecou) {
			Destroy(dragaoDormindo);
			comecou = true;
			player = other.GetComponent<MovimentoHumanoide>();
			player.Habilitado = false;
			
			Transform dragaoObject = (Transform)Instantiate(dragaoPrefab, dragaoStart.position, dragaoStart.rotation);
			dragao = dragaoObject.GetComponent<DragaoScript>();
			dragao.UsarFogo();
			dragao.transform.RotateAround(dragao.transform.position, Vector3.up, 180);
		}
	}
	
	void Update () {
		if (comecou) {
			cronometro += Time.deltaTime;
			
			// Camera seguindo o dragão
			if (cronometro < 6) {
				dragao.transform.position = Vector3.Lerp(dragaoStart.position, dragaoEnd.position, cronometro / 6f);
				Camera.main.transform.position = dragao.transform.position - new Vector3(4.5f, 0.3f, 0);
				Camera.main.transform.LookAt(dragao.transform);

				// Voltando pra câmera normal e destruindo o evento e dragão.
			} else {
				cameraRotation.ResetCamera();
				Destroy(dragao.gameObject);
				Destroy(player1.transform.GetChild(0).gameObject);
				Destroy(player1.transform.GetChild(1).gameObject);
				Destroy(this.gameObject);
			}
		}
	}
}
