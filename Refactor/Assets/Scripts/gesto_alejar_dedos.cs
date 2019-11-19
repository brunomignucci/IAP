using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gesto_alejar_dedos : ADetector_gesto
{
    [SerializeField]
    GameObject go1, go2;
    private static float distancia_optima = 0.07f;
    

    public override bool detect()
    {
        return detecto_lejania();
    }

    private bool detecto_lejania()
    {
        Vector3 dis1, dis2;
        dis1 = go1.transform.position;
        dis2 = go2.transform.position;

        float distancia_entre_dedos = (dis1 - dis2).magnitude;
        if (distancia_entre_dedos > distancia_optima) return true;
        else return false;
       
        

    }
}
