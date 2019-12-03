using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccionadorLevantarPiedras : AAccionador
{

    private GameObject listaPiedras;
    private GameObject triggerPiedras;
    private int size;
    private TriggerPiedras scriptPiedras;
    private bool activadoLocal;
    private GameObject bloqueo;
    private static float ALTURA_MAXIMA = 50f;
    private bool piedrasActivadas;

    public override void accionar()
    {
      if(!activadoLocal){
        if(scriptPiedras.activated){
          activadoLocal = true;
          bloqueo.transform.Translate(new Vector3(100f,0,0),Space.World);
          //bloqueo.SetActive(false);
          for(int i=0; i<size; i++){
            GameObject piedra = listaPiedras.transform.GetChild(i).gameObject;
            Rigidbody rb = piedra.GetComponent<Rigidbody>();
            rb.useGravity = false;
            float fuerzaAleatoria = UnityEngine.Random.Range(5f, 10f) * 2000.0f;
            rb.AddForce(transform.up * fuerzaAleatoria);
          }
          piedrasActivadas = true;
        }
      }
    }



    // Start is called before the first frame update
    void Start()
    {
        piedrasActivadas = false;
        listaPiedras =  GameObject.Find("piedras");
        triggerPiedras = GameObject.Find("TriggerEntradaPiedras");
        size = listaPiedras.transform.childCount;
        scriptPiedras = triggerPiedras.GetComponent<TriggerPiedras>();
        activadoLocal = false;
        bloqueo = GameObject.Find("BloqueoPiedras").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
      if(piedrasActivadas){
        for(int i=0; i<size; i++){
          if(listaPiedras.transform.GetChild(i).transform.position.y >= ALTURA_MAXIMA){
            Destroy(listaPiedras.transform.GetChild(i).gameObject);
          }
        }
      }

    }
}
