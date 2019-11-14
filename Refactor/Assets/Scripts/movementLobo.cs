using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementLobo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject indice_izq;
    Vector3 posicion_ref,my_position,direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posicion_ref = indice_izq.transform.position;
        my_position = this.transform.position;
        direction = my_position -posicion_ref;
        //Debug.Log(direction.magnitude*100);
        //Debug.Log(direction);
    }
}
