using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffGravity : MonoBehaviour
{
    public GameObject pinky_right;
    public GameObject pinky_left;
    bool gravity = true;

    private Vector3 pos_pinky_izq;
    private Vector3 pos_pinky_der;
    private float distancia;

    bool puedo_tocar;

    // Start is called before the first frame update
    void Start()
    {
        puedo_tocar = true;
        if (Physics.gravity.y < 0.0f)
        {
            print("La gravedad esta prendida");
            gravity = true;

        }
        else
        {
            print(Physics.gravity.y);
            gravity = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos_pinky_der = pinky_right.transform.position;
        pos_pinky_izq = pinky_left.transform.position;
        distancia = (pos_pinky_der - pos_pinky_izq).magnitude;
        //Debug.Log(distancia);
        if (distancia < 0.03 && puedo_tocar)
        {
            puedo_tocar = false;
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
        if (distancia > 0.07)
        {
            puedo_tocar = true;
        }
    }
}