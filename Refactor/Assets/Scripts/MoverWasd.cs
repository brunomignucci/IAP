using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverWasd : MonoBehaviour
{
    Rigidbody rb; float speed; Vector3 pos;
    // Start is called before the first frame updateF
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        speed = 3f;

    }

    public float panSpeed = 20f;

    void Update()
    {
        pos = transform.position;

       
        if (Input.GetKey("q")) { transform.Rotate(0, -50f*Time.deltaTime, 0f); }
        if (Input.GetKey("e")) { transform.Rotate(0, 50f * Time.deltaTime, 0f); }
        if (Input.GetKey("s")) { transform.Rotate(50f * Time.deltaTime, 0f, 0f); }
        if (Input.GetKey("w")) { transform.Rotate(-50f * Time.deltaTime, 0f, 0f); }
		if (Input.GetKey("u")) { GetComponent<Server>().mover_adelante_leap(); }
		if (Input.GetKey("j")) { GetComponent<Server>().mover_atras_leap(); }
		transform.forward = this.transform.forward;
        transform.position = pos;
    }
}
