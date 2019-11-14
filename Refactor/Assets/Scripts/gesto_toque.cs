using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gesto_toque : ADetector_gesto
{
    [SerializeField]
    GameObject go1, go2;
    private static float distancia_optima = 0.01f;
    private static float distancia_reset = 0.07f;
    private bool toque = false;//estado interno

    public override bool detect()
    {
        return detecto_proximidad();
    }

    private bool detecto_proximidad()
    {
		bool toReturn = false;
        if (!toque) { 

           Vector3 obj1, obj2;
           float distancia;

           obj1 = go1.transform.position;
           obj2 = go2.transform.position;
           distancia = (obj1 - obj2).magnitude;

            if (distancia < distancia_optima)
             {
               
                toque = true;
                toReturn =  true;
               
            }
            
        }
        else
        {
            Vector3 obj1, obj2;
            float distancia;

            obj1 = go1.transform.position;
            obj2 = go2.transform.position;
            distancia = (obj1 - obj2).magnitude;

            if (distancia_reset < distancia) toque = false;
            toReturn= false;
        }
		return toReturn;

      }
}

