using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnableObject : NetworkBehaviour
{

	[SyncVar]
	float scale;

	[ClientRpc]
	void RpcScaleObject(float amount)
	{
		this.transform.localScale = new Vector3(amount, amount, amount);
	}

	public void ScaleObject(float newScale)
	{
		if (!isServer)
			return;

		scale = newScale;
		RpcScaleObject(scale);
	}
}