using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSettings : NetworkBehaviour
{
	[SerializeField]
	float MovementSpeed;
	[SerializeField]
	GameObject ClientCamera, ServerCamera, Gestos, LeapRig;
	private bool isLeapUser;
	// Start is called before the first frame update
	void Start()
	{
		isLeapUser = true;

		if (!isLocalPlayer)
		{
			//desactivar scripts de los clientes
			ClientCamera.SetActive(false);
			ServerCamera.SetActive(true);
		}
		if(!isServer)
		{
			//desactivar scripts del server
			LeapRig.SetActive(false);
			ClientCamera.SetActive(true);
			Gestos.SetActive(false);
			
		}

		if (!isLeapUser)
		{
			//desactivar scripts del cliente leap
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
	public float GetMovementSpeed()
	{
		return MovementSpeed;
	}
}
