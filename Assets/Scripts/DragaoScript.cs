using UnityEngine;
using System.Collections;

public class DragaoScript : MonoBehaviour {
    public Light luzDoFogo;
    public GameObject fogo;

    public void Voar() {
        animation.CrossFade("Flying");
        luzDoFogo.enabled = false;
        fogo.SetActive(false);
    }
    public void UsarFogo() {
        animation.CrossFade("Fire");
        luzDoFogo.enabled = true;
        fogo.SetActive(true);
    }
    public void Dormir() {
        animation.CrossFade("Sleeping");
        luzDoFogo.enabled = false;
        fogo.SetActive(false);
    }
}

