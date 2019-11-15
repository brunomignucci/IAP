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
	[SerializeField]
	GameObject MenuEntryCubo, MenuEntryEsfera, menu, toCreate, cuboToCreate, esferaToCreate;
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
			MenuEntryCubo.SetActive(false);
			MenuEntryEsfera.SetActive(false);			
		}

		if (!isLeapUser)
		{
			//desactivar scripts del cliente leap
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("w"))
		{
			//GetComponent<Client>().RpcSetSelectedHandMenuEntry(MenuEntryCubo.transform.GetSiblingIndex());

			menu.GetComponent<HandMenu>().SelectEntry(MenuEntryCubo.GetComponent<HandMenuEntry>());
			GetComponent<Server>().SetSelectedHandMenuEntry(MenuEntryCubo.transform.GetSiblingIndex());

			if (toCreate.transform.childCount > 0)
			{
				Destroy(toCreate.transform.GetChild(0).gameObject);
			}
			Instantiate(cuboToCreate, toCreate.transform);
			//menu_flag.SetActive(false);
		}
		if (Input.GetKey("e"))
		{
			//GetComponent<Client>().RpcSetSelectedHandMenuEntry(MenuEntryEsfera.transform.GetSiblingIndex());

			//GetComponent<Client>().RpcSetSelectedHandMenuEntry(MenuEntryCubo.transform.GetSiblingIndex());

			menu.GetComponent<HandMenu>().SelectEntry(MenuEntryEsfera.GetComponent<HandMenuEntry>());
			GetComponent<Server>().SetSelectedHandMenuEntry(MenuEntryEsfera.transform.GetSiblingIndex());

			if (toCreate.transform.childCount > 0)
			{
				Destroy(toCreate.transform.GetChild(0).gameObject);
			}
			Instantiate(esferaToCreate, toCreate.transform);
			//menu_flag.SetActive(false);
		}
	}
	public float GetMovementSpeed()
	{
		return MovementSpeed;
	}
}
