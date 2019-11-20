using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gesto_press_and_hold : ADetector_gesto
{
    [SerializeField]
    GameObject go1, go2;
	[SerializeField]
    private float distancia_optima = 0.02f;
    private bool state = false;//estado interno

    public override bool detect()
    {
        return detecto_proximidad();
    }

    private bool detecto_proximidad()
    {

        bool toReturn = false;

        Vector3 obj1, obj2;
        float distancia;

        obj1 = go1.transform.position;
        obj2 = go2.transform.position;
        distancia = (obj1 - obj2).magnitude;
        if (distancia < distancia_optima)
        {
            toReturn = true;
        }
        return toReturn;
    }

}

