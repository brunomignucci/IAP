using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RotatePuzzle : NetworkBehaviour
{
	public GameObject pilar;
	private GameObject toRotate;
	private bool debounce;
	private float velocidad;
	private Quaternion target;
	private float lastRotation;
	private bool termineMov;
	private Vector3 Origin;
	// Start is called before the first frame update
	void Start()
	{
		if (!isServer)
		{
			return;
		}
		velocidad = 5f;
		debounce = false;
		termineMov = false;
		toRotate = pilar.transform.GetChild(1).gameObject;
		//GetComponent<Renderer>().material.SetColor("_Color", Color.white);
		GetComponent<SpawnableObject>().ChangeColor(Color.white);
		target = Quaternion.Euler(0, toRotate.transform.localRotation.eulerAngles.y, 0);
		lastRotation = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isServer)
		{
			return;
		}
		//Debug.DrawRay(transform.position, Vector3.up, Color.yellow);
		//Debug.DrawRay (transform.position, Vector3.down, Color.yellow);
		if (termineMov)
		{
			//Debug.Log("Termine y puedo entrar");
			if (!debounce && (Physics.Raycast(transform.position, Vector3.up, 2)))
			{
				//Debug.Log("Entro");
				debounce = true;
				target = Quaternion.Euler(0, toRotate.transform.localRotation.eulerAngles.y + 90f, 0);
				//GetComponent<Renderer>().material.SetColor("_Color", Color.green);
				GetComponent<SpawnableObject>().ChangeColor(Color.green);
				termineMov = false;
			}
			else
			{
				if (!Physics.Raycast(transform.position, Vector3.up, 2))
					debounce = false;
			}
		}
		else
		{
		if (toRotate.transform.localRotation != target)
		{ //Si todavia no llego a destino
			toRotate.transform.localRotation = Quaternion.Slerp(toRotate.transform.localRotation, target, velocidad * Time.deltaTime);
			//Debug.Log("Sigo Moviendo");
		}
		else
		{ //Si ya llego a destino..... o esta muy cerca como para detectar una diferencia (Problema de precision)
			toRotate.transform.localRotation = Quaternion.Euler(0, Mathf.Ceil(toRotate.transform.localRotation.eulerAngles.y), 0);//Lo llevo al numero entero mas cercano
			termineMov = true; //Termino el movimiento
							   //GetComponent<Renderer>().material.SetColor("_Color", Color.white);//Cambio color para indicar que ya se puede activar
			GetComponent<SpawnableObject>().ChangeColor(Color.white);
		}
		}
	}

}
