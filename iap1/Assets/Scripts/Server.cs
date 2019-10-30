using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : NetworkBehaviour
{

	public GameObject LeapHandRight, LeapHandLeft;
	GameObject LeapRig;
	// Start is called before the first frame update
	void Start()
    {
		if (!isServer)
		{
			return;
		}
		LeapRig = GameObject.Find("Leap Rig");
		InvokeRepeating("updateHands", 1, 0.01f);
	
	}

    // Update is called once per frame
    void Update()
    {
        if(!isServer)
		{
			return;
		}

		if (Input.GetKey("z"))
		{
			GetComponent<Client>().RpcRotarPlayer(new Vector3(0, 0, 1));
		}
		if (Input.GetKey("v"))
		{

			GetComponent<Client>().RpcRotarPlayer(new Vector3(1, 0, 0));
		}
		if (Input.GetKey("y"))
		{

			GetComponent<Client>().RpcRotarPlayer(new Vector3(0, 1, 0));
		}
		if (Input.GetKey("c"))
		{
			GetComponent<Client>().RpcCentrarCamara();
		}
	}

	void updateHands()
	{
		//Transform[] handTransform = LeapHandRight.GetComponentsInChildren<Transform>();
		Vector3[] positions_dedos0 = new Vector3[5];
		Vector3[] positions_dedos1 = new Vector3[5];
		Vector3[] positions_dedos2 = new Vector3[7];
		Quaternion[] rotations_dedos0 = new Quaternion[5];
		Quaternion[] rotations_dedos1 = new Quaternion[5];
		Quaternion[] rotations_dedos2 = new Quaternion[7];
		Vector3[] positions_dedos0l = new Vector3[5];
		Vector3[] positions_dedos1l = new Vector3[5];
		Vector3[] positions_dedos2l = new Vector3[7];
		Quaternion[] rotations_dedos0l = new Quaternion[5];
		Quaternion[] rotations_dedos1l = new Quaternion[5];
		Quaternion[] rotations_dedos2l = new Quaternion[7];

		Vector3[] position_menu = new Vector3[2];
		Quaternion[] rotation_menu = new Quaternion[2];

		Transform wrist_transform = LeapHandRight.transform;
		Transform wrist_transforml = LeapHandLeft.transform;

		Transform palma = wrist_transform.GetChild(0);
		Transform palmal = wrist_transforml.GetChild(0);


		// guardo la posiciony rotacion de las palmas en 2:5
		positions_dedos2[5] = palma.position;
		rotations_dedos2[5] = palma.rotation;
		positions_dedos2l[5] = palmal.position;
		rotations_dedos2l[5] = palmal.rotation;


		// MANO DERECHA
		Transform thumb = palma.GetChild(0);
		Transform index = palma.GetChild(1);
		Transform middle = palma.GetChild(2);
		Transform pinky = palma.GetChild(3);
		Transform ring = palma.GetChild(4);
		Transform refMov = palma.GetChild(5);

		// en 0 el dedo gordo
		positions_dedos0[0] = thumb.GetChild(0).position;
		rotations_dedos0[0] = thumb.GetChild(0).rotation;
		positions_dedos1[0] = thumb.GetChild(0).GetChild(0).position;
		rotations_dedos1[0] = thumb.GetChild(0).GetChild(0).rotation;
		positions_dedos2[0] = thumb.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2[0] = thumb.GetChild(0).GetChild(0).GetChild(0).rotation;

		// en 1 el dedo indice

		positions_dedos0[1] = index.GetChild(0).position;
		rotations_dedos0[1] = index.GetChild(0).rotation;
		positions_dedos1[1] = index.GetChild(0).GetChild(0).position;
		rotations_dedos1[1] = index.GetChild(0).GetChild(0).rotation;
		positions_dedos2[1] = index.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2[1] = index.GetChild(0).GetChild(0).GetChild(0).rotation;

		// en 2 el dedo middle

		positions_dedos0[2] = middle.GetChild(0).position;
		rotations_dedos0[2] = middle.GetChild(0).rotation;
		positions_dedos1[2] = middle.GetChild(0).GetChild(0).position;
		rotations_dedos1[2] = middle.GetChild(0).GetChild(0).rotation;
		positions_dedos2[2] = middle.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2[2] = middle.GetChild(0).GetChild(0).GetChild(0).rotation;

		// en 3 el pinky

		positions_dedos0[3] = pinky.GetChild(0).position;
		rotations_dedos0[3] = pinky.GetChild(0).rotation;
		positions_dedos1[3] = pinky.GetChild(0).GetChild(0).position;
		rotations_dedos1[3] = pinky.GetChild(0).GetChild(0).rotation;
		positions_dedos2[3] = pinky.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2[3] = pinky.GetChild(0).GetChild(0).GetChild(0).rotation;

		// en 4 el ring

		positions_dedos0[4] = ring.GetChild(0).position;
		rotations_dedos0[4] = ring.GetChild(0).rotation;
		positions_dedos1[4] = ring.GetChild(0).GetChild(0).position;
		rotations_dedos1[4] = ring.GetChild(0).GetChild(0).rotation;
		positions_dedos2[4] = ring.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2[4] = ring.GetChild(0).GetChild(0).GetChild(0).rotation;

		// referencia de movimiento

		positions_dedos2[6] = refMov.position;
		rotations_dedos2[6] = refMov.rotation;

		// MANO IZQUIERDA

		Transform thumbl = palmal.GetChild(0);
		Transform indexl = palmal.GetChild(1);
		Transform middlel = palmal.GetChild(2);
		Transform pinkyl = palmal.GetChild(3);
		Transform ringl = palmal.GetChild(4);
		Transform cubo = palmal.GetChild(5);
		Transform sphere = palmal.GetChild(6);

		// en 0 el dedo gordo
		positions_dedos0l[0] = thumbl.GetChild(0).position;
		rotations_dedos0l[0] = thumbl.GetChild(0).rotation;
		positions_dedos1l[0] = thumbl.GetChild(0).GetChild(0).position;
		rotations_dedos1l[0] = thumbl.GetChild(0).GetChild(0).rotation;
		positions_dedos2l[0] = thumbl.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2l[0] = thumbl.GetChild(0).GetChild(0).GetChild(0).rotation;

		// en 1 el dedo indice

		positions_dedos0l[1] = indexl.GetChild(0).position;
		rotations_dedos0l[1] = indexl.GetChild(0).rotation;
		positions_dedos1l[1] = indexl.GetChild(0).GetChild(0).position;
		rotations_dedos1l[1] = indexl.GetChild(0).GetChild(0).rotation;
		positions_dedos2l[1] = indexl.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2l[1] = indexl.GetChild(0).GetChild(0).GetChild(0).rotation;

		// en 2 el dedo middle

		positions_dedos0l[2] = middlel.GetChild(0).position;
		rotations_dedos0l[2] = middlel.GetChild(0).rotation;
		positions_dedos1l[2] = middlel.GetChild(0).GetChild(0).position;
		rotations_dedos1l[2] = middlel.GetChild(0).GetChild(0).rotation;
		positions_dedos2l[2] = middlel.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2l[2] = middlel.GetChild(0).GetChild(0).GetChild(0).rotation;

		// en 3 el pinky

		positions_dedos0l[3] = pinkyl.GetChild(0).position;
		rotations_dedos0l[3] = pinkyl.GetChild(0).rotation;
		positions_dedos1l[3] = pinkyl.GetChild(0).GetChild(0).position;
		rotations_dedos1l[3] = pinkyl.GetChild(0).GetChild(0).rotation;
		positions_dedos2l[3] = pinkyl.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2l[3] = pinkyl.GetChild(0).GetChild(0).GetChild(0).rotation;

		// en 4 el ring

		positions_dedos0l[4] = ringl.GetChild(0).position;
		rotations_dedos0l[4] = ringl.GetChild(0).rotation;
		positions_dedos1l[4] = ringl.GetChild(0).GetChild(0).position;
		rotations_dedos1l[4] = ringl.GetChild(0).GetChild(0).rotation;
		positions_dedos2l[4] = ringl.GetChild(0).GetChild(0).GetChild(0).position;
		rotations_dedos2l[4] = ringl.GetChild(0).GetChild(0).GetChild(0).rotation;

		// menu

		position_menu[0] = cubo.position;
		rotation_menu[0] = cubo.rotation;

		position_menu[1] = sphere.position;
		rotation_menu[1] = sphere.rotation;


		GetComponent<Client>().RpcUpdateHands(positions_dedos0, rotations_dedos0, positions_dedos1, rotations_dedos1, positions_dedos2, rotations_dedos2,
			positions_dedos0l, rotations_dedos0l, positions_dedos1l, rotations_dedos1l, positions_dedos2l, rotations_dedos2l, position_menu, rotation_menu);
	}

	[Command]
	public void CmdUpdateServerCamera(Quaternion newRot)
	{
		//transform.rotation = newRot;
		LeapRig.transform.rotation = newRot;
	}

}
