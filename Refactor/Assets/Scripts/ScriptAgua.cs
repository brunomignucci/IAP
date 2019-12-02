using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAgua : MonoBehaviour
{
	[SerializeField]
	private GameObject indice_izq, indice_der, pulgar, particulas, posicionOrigen;
	[SerializeField]
	private GameObject flag; // network transform que si esta en y menor a 0 desactivar el agua

	private Plane plano_forward;

	private GameObject[] flags;

	bool encontre_flag;

	void Start()
	{

	}


	void Update()
	{

	}

	public void ActivarAgua()
	{

		if (particulas.activeSelf == false)
		{
			//si las particulas estan desactivadas las activo
			particulas.SetActive(true);
			//flag.transform.position= new Vector3(0, -5, 0);
		}
		plano_forward.Set3Points(indice_izq.transform.position, pulgar.transform.position, indice_der.transform.position);
		particulas.gameObject.transform.GetChild(0).position = posicionOrigen.transform.position;
		particulas.gameObject.transform.GetChild(0).forward = plano_forward.normal;

		Ray rayo = new Ray(pulgar.transform.position, plano_forward.normal);
		RaycastHit hit;
		if (Physics.Raycast(rayo, out hit, 10.0f))
		{
			if (hit.transform.parent != null && hit.transform.parent.tag == "ARBOLES" && hit.transform.gameObject.tag == "FUEGO" && hit.transform.GetChild(0).gameObject.activeSelf == true)
			{
				GameObject.Find("Fuego").GetComponent<ApagarFuego>().apagar(hit.transform.gameObject);
				//Debug.Log("Entro al if");
			}
			//else Debug.Log("No entra al if");
		}


		//acá habria que hacer la lógica de que collidee el bosque

		//actualizo vectores de posicion y 
	}
	public void DesactivarAgua()
	{
		if (particulas.activeSelf == true)
		{
			//si las particulas estan activas las desactivo
			particulas.SetActive(false);
			//flag.transform.position = new Vector3(0, 5, 0);

		}

	}
}
