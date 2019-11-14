using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlGravity : AAccionador
{
    private bool activated = true;
    private GameObject lista;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
      lista = GameObject.Find("/ListaObjetosCreados");
    }

    public override void accionar()
    {
        if(activated){
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
          activated = true;
          Physics.gravity = new Vector3(0f,-9.8f,0f);
        }
    }
}
