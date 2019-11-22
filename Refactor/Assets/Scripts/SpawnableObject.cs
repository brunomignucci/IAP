using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnableObject : NetworkBehaviour
{

	[SyncVar]
	float scale;
	[SyncVar]
	Color color;

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

	[ClientRpc]
	void RpcChangeColor(Color newColor)
	{
		this.GetComponent<Renderer>().material.color = newColor;
	}

	public void ChangeColor(Color newColor)
	{
		if (!isServer)
			return;

		color = newColor;
		this.GetComponent<Renderer>().material.color = newColor;
		RpcChangeColor(color);
	}
}