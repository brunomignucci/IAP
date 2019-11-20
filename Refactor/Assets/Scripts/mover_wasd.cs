using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_wasd : MonoBehaviour
{
    Rigidbody rb; float speed; Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        speed = 3f;

    }

    public float panSpeed = 20f;

    void Update()
    {
        pos = transform.position;

       
        if (Input.GetKey("q")) { transform.Rotate(0, -1f, 0f); }
        if (Input.GetKey("e")) { transform.Rotate(0, 1f, 0f); }
        if (Input.GetKey("s")) { transform.Rotate(1f, 0f, 0f); }
        if (Input.GetKey("w")) { transform.Rotate(-1f, 0f, 0f); }
        transform.forward = this.transform.forward;
        transform.position = pos;
    }
}
