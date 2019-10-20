using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalGravity : MonoBehaviour
{
    bool gravity;

    // Start is called before the first frame update
    void Start()
    {
        gravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if (gravity)
            {
                gravity = false;
                Physics.gravity = new Vector3(0.0f, 0.0f, 0.0f);
            }
            else
            {
                gravity = true;
                Physics.gravity = new Vector3(0.0f, -9.8f, 0.0f);
            }


        }
    }
}
