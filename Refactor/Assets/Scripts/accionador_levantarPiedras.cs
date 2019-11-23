using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class accionador_levantarPiedras : AAccionador
{

    private GameObject listaPiedras;
    private GameObject triggerPiedras;
    private int size;
    private TriggerPiedras scriptPiedras;
    private bool activadoLocal;

    public override void accionar()
    {
      if(!activadoLocal){
        if(scriptPiedras.activated){
          activadoLocal = true;
          listaPiedras.GetComponent<Collider>().enabled = false;
          for(int i=0; i<size; i++){
            GameObject piedra = listaPiedras.transform.GetChild(i).gameObject;
            Rigidbody rb = piedra.GetComponent<Rigidbody>();
            rb.useGravity = false;
            float fuerzaAleatoria = UnityEngine.Random.Range(5f, 10f) * 500.0f;
            rb.AddForce(transform.up * fuerzaAleatoria);
          }
        }
      }
    }

    // Start is called before the first frame update
    void Start()
    {
        listaPiedras =  GameObject.Find("piedras");
        triggerPiedras = GameObject.Find("TriggerEntradaPiedras");
        size = listaPiedras.transform.childCount;
        scriptPiedras = triggerPiedras.GetComponent<TriggerPiedras>();
        activadoLocal = false;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
