using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{

    public float movementSpeed;
    bool cambie;
    // Use this for initialization
    void Start()
    {

    }

    //Update is called once per frame
    void Update ()
    {
        Vector3 nueva_pos= new Vector3(0,0,0);
		float delta = 0.0f;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
			//transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
			//nueva_pos = transform.position + transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
			delta = Time.deltaTime * movementSpeed * 2.5f;
            cambie = true;
        }
        else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
			//transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
			//nueva_pos = transform.position + transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
			delta = Time.deltaTime * movementSpeed;

			cambie = true;
        }
        else if (Input.GetKey("s"))
        {
			//transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
			//nueva_pos = transform.position - transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
			delta = - Time.deltaTime * movementSpeed;
			cambie = true;
        }

        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            //transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            // transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
            //nueva_pos = transform.position - transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }

        if (cambie)
			//transform.GetComponent<PlayerController>().RpcMoverPlayer(nueva_pos);
			transform.GetComponent<Client>().RpcMoverPlayer(delta);
			cambie = false;
    }
}