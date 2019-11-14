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
	private GameObject ClientHandRight, ClientHandLeft, ClientCamera, Head;
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
	public void RpcMoverPlayer(int movDir)
	{
        GetComponent<movementClient>().moverPlayer(movDir);
	}

    /*
     * Metodos implementados para debugging
	[ClientRpc]
	public void RpcRotarPlayer(Vector3 delta)
	{
		transform.Rotate(delta);
	}

	[ClientRpc]
	public void RpcCentrarCamara()
	{
		UnityEngine.XR.InputTracking.disablePositionalTracking = true;
		UnityEngine.XR.InputTracking.Recenter();
		UnityEngine.XR.InputTracking.disablePositionalTracking = false;
	}*/

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
}
