using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accionador_agua : AAccionador
{
    //[SerializeField]
    //GameObject particulas, a, b, c;
    private GameObject fuego;

    private Plane plano_forward;
    private int contador = 0;

    private bool activo = false;

    public override void accionar()
    {
        accionar_agua();
    }
    //plane=newplane
    //
    private void Start()
    {
        //fuego = GameObject.Find("Fuego");
    }
    private void accionar_agua()
    {

        transform.root.GetComponent<Server>().SetWaterEnable(true);
        
        /*
        if (particulas.activeSelf == false)
        {
            Debug.Log("active");
            particulas.SetActive(true);


        }
        plano_forward.Set3Points(a.transform.position, b.transform.position, c.transform.position);
        particulas.gameObject.transform.GetChild(0).position = a.transform.position;
        particulas.gameObject.transform.GetChild(0).forward = plano_forward.normal;
        */
    }
  
}
