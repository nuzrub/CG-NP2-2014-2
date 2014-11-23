using UnityEngine;
using System.Collections;

public class PlataformaMovel : MonoBehaviour {

	[SerializeField]
	Transform plataforma;

	[SerializeField]
	Transform inicioTransform;

	[SerializeField]
	Transform finalTransform;

	[SerializeField]
	float speed;

	Vector3 direcao;
	Transform destino;

	void Start()
	{
		setDestino (inicioTransform);
	}

	void FixedUpdate()
	{
		plataforma.rigidbody.MovePosition (plataforma.position + direcao * speed * Time.fixedDeltaTime);

		if (Vector3.Distance (plataforma.position, destino.position) < speed * Time.fixedDeltaTime) 
		{
			setDestino(destino == inicioTransform ? finalTransform : inicioTransform);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (inicioTransform.position, plataforma.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (finalTransform.position, plataforma.localScale);
	}

	void setDestino(Transform dest)
	{
		destino = dest;
		direcao = (destino.position - plataforma.position).normalized;
	}

}
