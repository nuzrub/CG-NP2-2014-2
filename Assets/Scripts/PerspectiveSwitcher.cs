using UnityEngine;
using System.Collections;

public class PerspectiveSwitcher : MonoBehaviour
{
	bool ortho = true;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			ortho = !ortho;
			if (ortho)
			    camera.orthographic = true;
			else
				camera.orthographic = false;
		}
	}
}