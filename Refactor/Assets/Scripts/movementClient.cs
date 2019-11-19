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
    [SerializeField]
    float speed;
    Vector3 proj;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        proj = new Vector3(1, 0, 1);
        rb = GetComponent<Rigidbody>();
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
        //float mH = Input.GetAxis("Horizontal");
        //float mV = Input.GetAxis("Vertical");

        //Debug.Log(" a punto de mover hacia adelante");
        //Vector3 v= Vector3.Normalize(Vector3.Scale(proj, ClientCamera.transform.forward));
        //rb.velocity = v * speed*direction;

        //if (direction == -1) {
        //    Debug.Log(" a punto de mover hacia atras");
        //    Vector3 v = Vector3.Normalize(Vector3.Scale(proj, ClientCamera.transform.forward));
        //    rb.velocity = new Vector3(0f, 0f, 1f) * speed;
        //}
        //rb.AddForce(new Vector3(0f,0f,1f)*speed,ForceMode.Impulse);

        float delta = direction * Time.deltaTime * GetComponent<PlayerSettings>().GetMovementSpeed();
        transform.Translate(Vector3.Normalize(Vector3.Scale(proj, ClientCamera.transform.forward)) * delta , Space.World);

    }


}
