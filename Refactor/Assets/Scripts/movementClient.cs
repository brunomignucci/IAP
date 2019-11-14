using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
    Es la clase donde estan todos los RPC del cliente.
     
     
     */

public class movementClient : NetworkBehaviour
{
	[SerializeField]
	private GameObject ClientHandRight, ClientHandLeft, ClientCamera, Head;
    Vector3 proj;
    // Start is called before the first frame update
    void Start()
    {
        proj = new Vector3(1, 0, 1);
        if (!isLocalPlayer)
		{
			return;
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }

    public void moverPlayer(int direction) {
        float delta = direction * Time.deltaTime * GetComponent<PlayerSettings>().GetMovementSpeed();
        transform.Translate(Vector3.Normalize(Vector3.Scale(proj, ClientCamera.transform.forward)) * delta , Space.World);
    }
		
	
}
