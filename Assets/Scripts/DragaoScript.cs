using UnityEngine;
using System.Collections;

public class DragaoScript : MonoBehaviour {
    public Light luzDoFogo;
    public GameObject fogo;

	//Metodo para iniciar a animacao de voo do dragao;
    public void Voar() {
        animation.CrossFade("Flying");
        luzDoFogo.enabled = false;
        fogo.SetActive(false);
    }
	//Metodo para iniciar a animacao do dragao lancar fogo pela boca.
    public void UsarFogo() {
        animation.CrossFade("Fire");
        luzDoFogo.enabled = true;
        fogo.SetActive(true);
    }
	//Metodo para iniciar a animacao do dragao dormindo.
    public void Dormir() {
        animation.CrossFade("Sleeping");
        luzDoFogo.enabled = false;
        fogo.SetActive(false);
    }
}

