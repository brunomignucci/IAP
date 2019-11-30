using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControlP2 : MonoBehaviour
{
    
    public GameObject camera;
    Rigidbody rb;
    public float velocity;
    private float movH;
    private float movV;
    private Vector3 direction;
    float factor;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        factor = 0.01f;
        

    }

    // Update is called once per frame
    void Update()
    {
        direction = camera.transform.forward;
        movH = CrossPlatformInputManager.GetAxis("Horizontal") * velocity*factor;
        movV = CrossPlatformInputManager.GetAxis("Vertical") * velocity*factor;
        //rb.AddForce(movH, 0, movV);        
        this.transform.Translate(direction.x*movH, 0, direction.y*movV);
    }
}
