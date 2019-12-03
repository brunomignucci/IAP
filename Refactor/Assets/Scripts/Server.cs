using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : NetworkBehaviour
{
	[SerializeField]
	private GameObject LeapHandRight, LeapHandLeft, LeapRig;
	[SerializeField]
	private int HandUpdateRate;
	private bool aguaActivada = false;

	public void mover_adelante_leap()
	{
		GetComponent<Client>().RpcMoverPlayer(1 * Time.deltaTime);
	}

	internal void SetSelectedHandMenuEntry(int i)
	{
		GetComponent<Client>().RpcSetSelectedHandMenuEntry(i);
	}


	public void mover_atras_leap()
	{
		GetComponent<Client>().RpcMoverPlayer(-1 * Time.deltaTime);
	}

	public void DisableHand(int handedness)
	{
		GetComponent<Client>().RpcDisableHand(handedness);
	}

	// Start is called before the first frame update
	void Start()
	{
		if (!isServer)
		{
			return;
		}
		InvokeRepeating("updateHands", 1, 1.0f / HandUpdateRate);
	}

	// Update is called once per frame
	void Update()
	{
		if (!isServer)
		{
			return;
		}
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
		if (LeapHandLeft.activeInHierarchy)
		{
			GetComponent<Client>().RpcUpdateHand(
				LeapHandLeft.GetComponent<LeapHandScript>().getHandPositionsLocal(),
				LeapHandLeft.GetComponent<LeapHandScript>().getHandRotationsLocal(),
				2
			);
		}
	}


	[Command]
	public void CmdUpdateServerCamera(Quaternion newRot)
	{
		//transform.rotation = newRot;
		LeapRig.transform.rotation = newRot;
	}

	public void toggleWater()
	{
		//si esta activada, desactivo
	}

	public void SetHandMenuActive(bool active)
	{
		GetComponent<Client>().RpcSetHandMenuActive(active);
	}
	public void SetWaterEnable(bool active)
	{
        if (aguaActivada)
        {
            GetComponent<Client>().RpcRotYFire();
        }
		if (active && !aguaActivada)
		{
			GetComponent<Client>().RpcEnableWater();
			aguaActivada = true;
		}
		else
		{            
			if (!active && aguaActivada)
			{
				GetComponent<Client>().RpcDisableWater();
				aguaActivada = false;
			}
		}
	}


}
