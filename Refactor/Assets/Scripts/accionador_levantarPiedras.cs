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
    private Text GravityStatus;
    private Text Mision;
    public override void accionar()
    {
      if(scriptPiedras.activated && !activadoLocal){
        Debug.Log("Desactivo gravedad para las piedras");
        activadoLocal = true;
        listaPiedras.GetComponent<Collider>().enabled = false;
        for(int i=0; i<size; i++){
          GameObject piedra = listaPiedras.transform.GetChild(i).gameObject;
          Rigidbody rb = piedra.GetComponent<Rigidbody>();
          rb.useGravity = false;
          float fuerzaAleatoria = UnityEngine.Random.Range(5f, 10f) * 200.0f;
          rb.AddForce(transform.up * fuerzaAleatoria);
        }
      }
      else{
        Debug.Log("No puedo desactivar Gravedad");
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
        GravityStatus = GameObject.Find("GravityStatus").GetComponent<Text>();
        Mision = GameObject.Find("Mision").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


    }
}
