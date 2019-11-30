using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
    Es la clase donde estan todos los RPC del cliente.
      
     */

public class MovementClient : NetworkBehaviour
{
	[SerializeField]
	private GameObject ClientHandRight, ClientHandLeft, ClientCamera;
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

    public void moverPlayer(float delta) {
		Vector3 direction = Vector3.Normalize(Vector3.Scale(proj, ClientCamera.transform.forward));
		delta = delta * GetComponent<PlayerSettings>().GetMovementSpeed();
		//float mH = Input.GetAxis("Horizontal");
		//float mV = Input.GetAxis("Vertical");

		//Debug.Log(" a punto de mover hacia adelante");
		//Vector3 v= Vector3.Normalize(Vector3.Scale(proj, ClientCamera.transform.forward));
		//rb.velocity = v * speed*direction;

		//if (delta < 0)
		//{
		//	//debug.log(" a punto de mover hacia atras");
		//	vector3 v = vector3.normalize(vector3.scale(proj, clientcamera.transform.forward));
		//	rb.velocity = new vector3(0f, 0f, 1f) * speed;
		//}
		//rb.AddForce(direction*delta,ForceMode.Impulse);
		rb.MovePosition(transform.position + direction*delta);

		//float delta = direction * Time.deltaTime * GetComponent<PlayerSettings>().GetMovementSpeed();
		//transform.Translate(Vector3.Normalize(Vector3.Scale(proj, ClientCamera.transform.forward)) * delta , Space.World);
		
		//transform.Translate(direction * delta, Space.World);


	}


}
