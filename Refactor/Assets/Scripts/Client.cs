using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
    Es la clase donde estan todos los RPC del cliente.
     
     
     */

public class Client : NetworkBehaviour
{
	[SerializeField]
	private GameObject ClientHandRight, ClientHandLeft, ClientCamera, Head, HandMenu;
	// Start is called before the first frame update
	void Start()
    {
        if(!isLocalPlayer)
		{
			return;
		}
	}

	// Update is called once per frame
	void Update()
    {
		if(!isLocalPlayer)
		{
			return;
		}

		Head.transform.rotation = ClientCamera.transform.rotation;
		GetComponent<Server>().CmdUpdateServerCamera(ClientCamera.transform.rotation);
		
    }

	public override void OnStartLocalPlayer()
	{
		//GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	[ClientRpc]
	public void RpcMoverPlayer(float delta)
	{
        GetComponent<MovementClient>().moverPlayer(delta);
	}

	[ClientRpc]
	public void RpcUpdateHand(Vector3[] newPositions, Quaternion[] newRotations, int handedness)
	{
		if (handedness == 1)
		{
			ClientHandRight.SetActive(true);
			ClientHandRight.GetComponent<ClientHandScript>().UpdateHand(newPositions, newRotations);
		}
		if (handedness == 2)
		{
			ClientHandLeft.SetActive(true);
			ClientHandLeft.GetComponent<ClientHandScript>().UpdateHand(newPositions, newRotations);
		}

	}

	[ClientRpc]
	public void RpcDisableHand(int handedness)
	{
		if (handedness == 1)
		{
			ClientHandRight.SetActive(false);
		}
		if (handedness == 2)
		{
			ClientHandLeft.SetActive(false);
		}
	}

	[ClientRpc]
	public void RpcSetHandMenuActive(bool active)
	{
		HandMenu.SetActive(active);
	}

	[ClientRpc]
	public void RpcSetSelectedHandMenuEntry(int i)
	{
		HandMenu.GetComponent<HandMenu>().SelectEntry(i);
	}
    [ClientRpc]
    public void RpcEnableWater()
    {
        ClientCamera.GetComponent<ScriptAgua>().ActivarAgua();
    }
    [ClientRpc]
    public void RpcDisableWater()
    {
        ClientCamera.GetComponent<ScriptAgua>().DesactivarAgua();
    }
}
