using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	        //. ....
		    //.  O
			//. /|\
			//.  |
			//. / \
			//.
			//=========

	public Light luz;
	public float intensidade;
	public float velocidade = 1.0f;

	public float limiteSuperior = 1.0f;
	public float limiteInferior = 0.0f;

	void Start()
	{
		luz.intensity = 0.0f;
	}

	// Update is called once per frame (formatacao xapada)
	void Update () {
		if (Input.GetKey(KeyCode.M)) {
			if (luz.intensity < limiteSuperior) {
				luz.intensity = luz.intensity + (velocidade * Time.deltaTime);
				intensidade = luz.intensity;
			}
		} 

		if (Input.GetKey(KeyCode.N)) {
					
			if(luz.intensity > limiteInferior)	{
				luz.intensity = luz.intensity - (velocidade * Time.deltaTime);
				intensidade = luz.intensity;
			}

		}

	}
	
}