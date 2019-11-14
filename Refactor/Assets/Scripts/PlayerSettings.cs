using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSettings : NetworkBehaviour
{
	[SerializeField]
	float MovementSpeed;
	private bool isLeapUser;
	// Start is called before the first frame update
	void Start()
	{
		isLeapUser = true;
		GameObject ClientCamera = GameObject.Find("ClientCamera");
		GameObject ServerCamera = GameObject.Find("ServerCamera");

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
			GameObject.Find("Leap Rig").SetActive(false);

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
	public float GetMovementSpeed()
	{
		return MovementSpeed;
	}
}
