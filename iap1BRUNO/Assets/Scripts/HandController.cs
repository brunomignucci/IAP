using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HandController : NetworkBehaviour
{
    //Transform handSpawn;

    // Start is called before the first frame update
    void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!isServer)
		{
			return;
		}


		if (Input.GetKeyDown(KeyCode.U))
		{
			GetComponent<Rigidbody>().velocity = transform.up * 6.0f;

		}
		if(Input.GetKeyUp(KeyCode.U))
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		}

		if(Input.GetKeyDown(KeyCode.H))
		{
			GetComponent<Rigidbody>().velocity = -transform.right * 6.0f;
		}

		if (Input.GetKeyUp(KeyCode.H))
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.J))
		{
			GetComponent<Rigidbody>().velocity = -transform.up * 6.0f;

		}
		if (Input.GetKeyUp(KeyCode.J))
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			GetComponent<Rigidbody>().velocity = transform.right * 6.0f;
		}

		if (Input.GetKeyUp(KeyCode.K))
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.Y))
		{
			GetComponent<Rigidbody>().velocity = transform.forward * 6.0f;

		}
		if (Input.GetKeyUp(KeyCode.Y))
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			GetComponent<Rigidbody>().velocity = -transform.forward * 6.0f;
		}

		if (Input.GetKeyUp(KeyCode.I))
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}
	}

	[ClientRpc]
	void RpcTranslate(Vector3 v)
	{
		if (isLocalPlayer)
		{
			transform.Translate(v);
		}

	}
}
