using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlGravity : AAccionador
{
    private bool activated = true;
    private GameObject lista;
    private Rigidbody rigidbody;
    private Text textoGravedad;
    // Start is called before the first frame update
    void Start()
    {
      lista = GameObject.Find("/ListaObjetosCreados");
      //textoGravedad = GameObject.Find("GravityStatus").GetComponent<Text>();
    }

    public override void accionar()
    {
        if(activated){
          //textoGravedad.text = "OFF";
          Physics.gravity = new Vector3(0.0f, 0.0f, 0.0f);
          int size = lista.transform.childCount;
          activated = false;
          for(int i=0; i<size; i++){
            GameObject objeto = lista.transform.GetChild(i).gameObject;
            Rigidbody rigid = objeto.GetComponent<Rigidbody>();
            float fuerzaAleatoria = UnityEngine.Random.Range(0.5f, 2.0f) * 5.0f;
            rigid.AddForce(transform.up * fuerzaAleatoria);
          }
        }
        else{
          //textoGravedad.text = "ON";
          activated = true;
          Physics.gravity = new Vector3(0f,-9.8f,0f);
        }
    }
}
