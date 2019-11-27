using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PuzzleManager : NetworkBehaviour
{
	public GameObject pilar1;
	public GameObject pilar2;
	public GameObject pilar3;
	public GameObject pilar4;
	private bool completoPilar1;
	private bool completoPilar2;
	private bool completoPilar3;
	private bool completoPilar4;

	private GameObject rotationPanel1;
	private GameObject rotationPanel2;
	private GameObject rotationPanel3;
	private GameObject rotationPanel4;

	public Finalizador puerta;

	private bool completo;
	// Start is called before the first frame update
	void Start()
	{
		if (!isServer)
		{
			return;
		}
		completo = completoPilar1 = completoPilar2 = completoPilar3 = completoPilar4 = false;
		rotationPanel1 = pilar1.transform.GetChild(1).gameObject;
		rotationPanel2 = pilar2.transform.GetChild(1).gameObject;
		rotationPanel3 = pilar3.transform.GetChild(1).gameObject;
		rotationPanel4 = pilar4.transform.GetChild(1).gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isServer)
		{
			return;
		}
		if (Input.GetKeyDown("p"))
		{
			Debug.Log(completoPilar1);
			Debug.Log(completoPilar2);
			Debug.Log(completoPilar3);
			Debug.Log(completoPilar4);
			Debug.Log(rotationPanel4.transform.rotation.eulerAngles.y);
			completo = true;
			puerta.abrirPuerta();
		}
		if (rotationPanel1.transform.localRotation.eulerAngles.y == 180f)
		{
			completoPilar1 = true;
			//Debug.Log("Completado Pilar 1");
			pilar1.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
		}
		else
		{
			completoPilar1 = false;
			pilar1.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
		}

		if (rotationPanel2.transform.localRotation.eulerAngles.y == 270f)
		{
			completoPilar2 = true;
			// Debug.Log("Completado Pilar 2");
			pilar2.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
		}
		else
		{
			completoPilar2 = false;
			pilar2.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
		}

		if (rotationPanel3.transform.localRotation.eulerAngles.y == 90f)
		{
			completoPilar3 = true;
			// Debug.Log("Completado Pilar 3");
			pilar3.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
		}
		else
		{
			completoPilar3 = false;
			pilar3.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
		}

		if (rotationPanel4.transform.localRotation.eulerAngles.y >= 0 && rotationPanel4.transform.localRotation.eulerAngles.y < 0.1)
		{
			completoPilar4 = true;
			//Debug.Log("Completado Pilar 4");
			pilar4.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
		}
		else
		{
			completoPilar4 = false;
			pilar4.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
		}

		if (completoPilar1 && completoPilar2 && completoPilar3 && completoPilar4 && !completo)
		{
			// Debug.Log("Puzzle Completo");
			completo = true;
			puerta.abrirPuerta();
		}
	}


}
