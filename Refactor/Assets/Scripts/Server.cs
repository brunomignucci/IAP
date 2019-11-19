using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : NetworkBehaviour
{
	[SerializeField]
	private GameObject LeapHandRight, LeapHandLeft, LeapRig;
	private Component Cliente;

	public void mover_adelante_leap()
	{
		GetComponent<Client>().RpcMoverPlayer(1);
	}

	internal void SetSelectedHandMenuEntry(int i)
	{
		GetComponent<Client>().RpcSetSelectedHandMenuEntry(i);
	}

	public void mover_atras_leap()
	{
		GetComponent<Client>().RpcMoverPlayer(-1);
	}
	// Start is called before the first frame update
	void Start()
	{
		if (!isServer)
		{
			return;
		}
		InvokeRepeating("updateHands", 1, 0.01f);
		Cliente = GetComponent<Client>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!isServer)
		{
			return;
		}

		//if (Input.GetKey("z"))
		//{
		//	GetComponent<Client>().RpcRotarPlayer(new Vector3(0, 0, 1));
		//}
		//if (Input.GetKey("v"))
		//{

		//	GetComponent<Client>().RpcRotarPlayer(new Vector3(1, 0, 0));
		//}
		//if (Input.GetKey("y"))
		//{

		//	GetComponent<Client>().RpcRotarPlayer(new Vector3(0, 1, 0));
		//}
		//if (Input.GetKey("c"))
		//{
		//	GetComponent<Client>().RpcCentrarCamara();
		//}

		/*
		if(LeapHandRight.GetComponent<leap_player_controller>().GetMovimiento() != 0)
		{
			GetComponent<Client>().RpcMoverPlayer(LeapHandRight.GetComponent<leap_player_controller>().GetMovimiento());
		}
        */
	}

	void updateHands()
	{
		if (LeapHandRight.activeInHierarchy)
		{
			GetComponent<Client>().RpcUpdateHand(
				LeapHandRight.GetComponent<LeapHandScript>().getHandPositionsLocal(),
				LeapHandRight.GetComponent<LeapHandScript>().getHandRotationsLocal(),
				1
			);
		}
		else
		{
			GetComponent<Client>().RpcDisableHand(1);
		}
		if (LeapHandLeft.activeInHierarchy)
		{
			GetComponent<Client>().RpcUpdateHand(
				LeapHandLeft.GetComponent<LeapHandScript>().getHandPositionsLocal(),
				LeapHandLeft.GetComponent<LeapHandScript>().getHandRotationsLocal(),
				2
			);
		}
		else
		{
			GetComponent<Client>().RpcDisableHand(2);
		}
	}


	[Command]
	public void CmdUpdateServerCamera(Quaternion newRot)
	{
		//transform.rotation = newRot;
		LeapRig.transform.rotation = newRot;
	}

	public void SetHandMenuActive(bool active)
	{
		GetComponent<Client>().RpcSetHandMenuActive(active);
	}
    public void SetWaterEnable(bool active)
    {
        if (active) GetComponent<Client>().RpcEnableWater();
        else GetComponent<Client>().RpcDisableWater();

    }

}
