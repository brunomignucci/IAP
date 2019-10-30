using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSettings : NetworkBehaviour
{
	GameObject ClientCamera, ServerCamera;
	bool isLeapUser;
	// Start is called before the first frame update
	void Start()
	{
		isLeapUser = true;
		ClientCamera = GameObject.Find("ClientCamera");
		ServerCamera = GameObject.Find("ServerCamera");

		if (!isLocalPlayer)
		{
			//desactivar scripts de los clientes
			ClientCamera.SetActive(false);
			ServerCamera.SetActive(true);
		}
		if(!isServer)
		{
			//desactivar scripts del server
			GetComponent<leap_player_controller>().enabled = false;
			GetComponent<player_control>().enabled = false;
			ClientCamera.SetActive(true);
			ServerCamera.SetActive(false);

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
}
