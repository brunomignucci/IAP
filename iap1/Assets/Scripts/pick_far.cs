using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_far : MonoBehaviour
{
    bool agarrando;
    Vector3 pos_inicial,ultima_posicion,pos_actual;
    public GameObject objecto_referencia;
    private GameObject objeto_detectado;
    int contador;
    // Start is called before the first frame update
    void Start()
    {
        agarrando = false;
        pos_inicial = this.transform.position;
        ultima_posicion = pos_inicial;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (agarrando)
        {
            objeto_detectado.transform.position = objecto_referencia.transform.position;
            contador++;
        }
        else { contador = 0; }

        if (contador > 4000) { agarrando = false; }
    }

    void OnTriggerStay(Collider other) 
    {
        if (!agarrando && other.tag!=("PLANO")) 
        {
            objeto_detectado = other.gameObject;
            objecto_referencia.transform.position = objeto_detectado.transform.position;
            agarrando = true;
        }
    }

   
}
