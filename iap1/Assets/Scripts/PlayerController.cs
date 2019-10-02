using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour
{

	public GameObject TestHand;
	public GameObject LeapHandRight;
    bool isLeapUser;

	// Start is called before the first frame update
	void Start()
	{
        isLeapUser = true;
	}

	// Update is called once per frame
	void Update()
	{

		if (isServer)
		{
			updateTestHand();
		}
		if (!isLocalPlayer)
		{
			return;
		}

		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

        if(!isLeapUser)
        {
            return;
        }

    }


	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	void updateTestHand(){
		//TestHand.transform.position = LeapHandRight.transform.GetChild(2).GetChild(2).position;
		RpcUpdateHands(LeapHandRight.transform.GetChild(2).GetChild(2).position);
	}

	[ClientRpc]
	void RpcUpdateHands(Vector3 newPos)
	{
		TestHand.transform.position = newPos;
	}
}
