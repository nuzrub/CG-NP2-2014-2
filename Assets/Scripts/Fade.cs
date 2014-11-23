using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public Light luz;
	public float velocidade = 0.6f;
	private float limiteSuperior = 0.5f;
    private float limiteInferior = 0.0f;


	void Update () {
		if (Input.GetKey(KeyCode.M)) {
			if (luz.intensity < limiteSuperior) {
				luz.intensity += velocidade * Time.deltaTime;
			}
		} 

		if (Input.GetKey(KeyCode.N)) {		
			if(luz.intensity > limiteInferior)	{
				luz.intensity -= velocidade * Time.deltaTime;
			}
		}
	}
}