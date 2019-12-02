using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectorObjetos : MonoBehaviour
{
    [SerializeField]
    private GameObject planta;
    [SerializeField]
    private GameObject piedra;
    [SerializeField]
    private GameObject caja;

    private Vector3 posInicialPlanta;
    private Vector3 posInicialPiedra;
    private Vector3 posInicialCaja;
    // private GameObject listaObjetos;
    private static float ALTURA_MINIMA = -20f;
    // private Vector3[] posicionesIniciales;
    // private int longitudListaObjetos;

    // Start is called before the first frame update
    void Start()
    {
        // longitudListaObjetos = listaObjetos.transform.childCount;
        // posicionesIniciales = new Vector3 [longitudListaObjetos];
        // for(int i = 0; i < posicionesIniciales.Length; i++)
        // {
        //     GameObject objeto = listaObjetos.transform.GetChild(i).gameObject;
        //     Vector3 posicion = objeto.transform.position;
        //     posicionesIniciales[i] = posicion;
        // }
        posInicialPlanta = planta.transform.position;
        posInicialPiedra = piedra.transform.position;
        posInicialCaja = caja.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // for(int i = 0; i < longitudListaObjetos; i++)
        // {
        //   GameObject objetoActual = listaObjetos.transform.GetChild(i).gameObject;
        //   Vector3 posicionActual = objetoActual.transform.position;
        //   if(posicionActual.y <= ALTURA_MINIMA)
        //   {
        //     posicionActual = posicionesIniciales[i];
        //   }
        // }
        if(planta.transform.position.y <= ALTURA_MINIMA)
        {
          planta.transform.position = posInicialPlanta;
          planta.GetComponent<Rigidbody>().velocity = new Vector3(0 , 0 , 0);
        }
        if(piedra.transform.position.y <= ALTURA_MINIMA)
        {
          piedra.transform.position = posInicialPiedra;
          piedra.GetComponent<Rigidbody>().velocity = new Vector3(0 , 0 , 0);
        }
        if(caja.transform.position.y <= ALTURA_MINIMA)
        {
          caja.transform.position = posInicialCaja;
          caja.GetComponent<Rigidbody>().velocity = new Vector3(0 , 0 , 0);
        }

    }
}
