using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	Transform smokePoint;
	Transform respawnPoint;
	public GameObject smoke;
	void Start() {
		respawnPoint = transform.GetChild(0);
		smokePoint = transform.GetChild (1);
	}

	//Metodo do Colider para retornar o jogador ao ponto inicial do puzzle.
	void OnTriggerEnter(Collider other) {
        Teleportar(other.transform);
	}

	//Metodo que teleporta o jogador ao ponto selecionado.
    public void Teleportar(Transform other) {
        Instantiate(smoke, smokePoint.position, smokePoint.rotation);
        other.position = respawnPoint.position;
        other.rotation = respawnPoint.rotation;
    }
}
