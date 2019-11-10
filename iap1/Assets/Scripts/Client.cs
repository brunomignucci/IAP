using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Client : NetworkBehaviour
{

	public GameObject ClientHandRight, ClientHandLeft;
	GameObject ClientCamera, Head;
	// Start is called before the first frame update
	void Start()
    {
        if(!isLocalPlayer)
		{
			return;
		}
		ClientCamera = GameObject.Find("ClientCamera");
		Head = GameObject.Find("Avatar/Head");
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
		Vector3 proj = new Vector3(1, 0, 1);

		//transform.Translate(Vector3.Normalize(Vector3.Scale(proj, transform.forward)) * delta, Space.World);
		transform.Translate(Vector3.Normalize(Vector3.Scale(proj, ClientCamera.transform.forward)) * delta, Space.World);
	}

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
	}

	//[ClientRpc]
	//public void RpcUpdateHands(Vector3[] positions_dedos0, Quaternion[] rotations_dedos0, Vector3[] positions_dedos1, Quaternion[] rotations_dedos1, Vector3[] positions_dedos2, Quaternion[] rotations_dedos2,
	//	Vector3[] positions_dedos0l, Quaternion[] rotations_dedos0l, Vector3[] positions_dedos1l, Quaternion[] rotations_dedos1l, Vector3[] positions_dedos2l, Quaternion[] rotations_dedos2l,
	//	Vector3[] position_menu, Quaternion[] rotation_menu)
	//{
	//	//intento asignar las posiciones de la mano del leap a la mano del cliente

	//	ClientHandRight.transform.GetChild(5).position = positions_dedos2[5];
	//	ClientHandRight.transform.GetChild(5).rotation = rotations_dedos2[5];
	//	ClientHandRight.transform.GetChild(5).rotation *= Quaternion.Euler(90, 0, 0);

	//	ClientHandLeft.transform.GetChild(5).position = positions_dedos2l[5];
	//	ClientHandLeft.transform.GetChild(5).rotation = rotations_dedos2l[5];
	//	ClientHandLeft.transform.GetChild(5).rotation *= Quaternion.Euler(90, 0, 0);

	//	ClientHandRight.transform.GetChild(5).GetChild(0).position = positions_dedos2[6];
	//	ClientHandRight.transform.GetChild(5).GetChild(0).rotation = rotations_dedos2[6];
	//	ClientHandRight.transform.GetChild(5).GetChild(0).rotation *= Quaternion.Euler(90, 0, 0);

	//	// menu

	//	ClientHandLeft.transform.GetChild(5).GetChild(0).position = position_menu[0];
	//	ClientHandLeft.transform.GetChild(5).GetChild(0).rotation = rotation_menu[0];
	//	ClientHandLeft.transform.GetChild(5).GetChild(0).rotation *= Quaternion.Euler(90, 0, 0);

	//	ClientHandLeft.transform.GetChild(5).GetChild(1).position = position_menu[1];
	//	ClientHandLeft.transform.GetChild(5).GetChild(1).rotation = rotation_menu[1];
	//	ClientHandLeft.transform.GetChild(5).GetChild(1).rotation *= Quaternion.Euler(90, 0, 0);

	//	//intento escalarlo en -1 para invertirlo
	//	int i;
	//	// intento mover la mano rigida
	//	for (i = 0; i < 7; i++)
	//	{
	//		if (i < 5)
	//		{
	//			ClientHandRight.transform.GetChild(i).GetChild(0).position = positions_dedos0[i];
	//			//positions_dedos0[i] = LeapHandRight.transform.GetChild(i).GetChild(0).position;
	//			ClientHandRight.transform.GetChild(i).GetChild(0).rotation = rotations_dedos0[i];
	//			ClientHandRight.transform.GetChild(i).GetChild(0).rotation *= Quaternion.Euler(90, 90, 0);
	//			ClientHandRight.transform.GetChild(i).GetChild(1).position = positions_dedos1[i];
	//			ClientHandRight.transform.GetChild(i).GetChild(1).rotation = rotations_dedos0[i];
	//			ClientHandRight.transform.GetChild(i).GetChild(1).rotation *= Quaternion.Euler(90, 90, 0);
	//			ClientHandRight.transform.GetChild(i).GetChild(2).position = positions_dedos2[i];
	//			ClientHandRight.transform.GetChild(i).GetChild(2).rotation = rotations_dedos0[i];
	//			ClientHandRight.transform.GetChild(i).GetChild(2).rotation *= Quaternion.Euler(90, 90, 0);



	//			ClientHandLeft.transform.GetChild(i).GetChild(0).position = positions_dedos0l[i];
	//			//positions_dedos0[i] = LeapHandRight.transform.GetChild(i).GetChild(0).position;
	//			ClientHandLeft.transform.GetChild(i).GetChild(0).rotation = rotations_dedos0l[i];
	//			ClientHandLeft.transform.GetChild(i).GetChild(0).rotation *= Quaternion.Euler(90, 90, 0);
	//			ClientHandLeft.transform.GetChild(i).GetChild(1).position = positions_dedos1l[i];
	//			ClientHandLeft.transform.GetChild(i).GetChild(1).rotation = rotations_dedos0l[i];
	//			ClientHandLeft.transform.GetChild(i).GetChild(1).rotation *= Quaternion.Euler(90, 90, 0);
	//			ClientHandLeft.transform.GetChild(i).GetChild(2).position = positions_dedos2l[i];
	//			ClientHandLeft.transform.GetChild(i).GetChild(2).rotation = rotations_dedos0l[i];
	//			ClientHandLeft.transform.GetChild(i).GetChild(2).rotation *= Quaternion.Euler(90, 90, 0);

	//		}

	//	}

	//}
	[ClientRpc]
	public void RpcUpdateHands(Vector3[] newPositions, Quaternion[] newRotations, bool isRightHand)
	{
		if (isRightHand)
		{
			ClientHandRight.GetComponent<ClientHandScript>().UpdateHand(newPositions, newRotations);
		}
		else
		{
			ClientHandLeft.GetComponent<ClientHandScript>().UpdateHand(newPositions, newRotations);
		}

	}

}
