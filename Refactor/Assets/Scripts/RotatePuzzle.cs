using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzle : MonoBehaviour
{
    public GameObject pilar;
    private GameObject toRotate;
    private bool debounce;
    private float velocidad;
    private Quaternion target;
    private float lastRotation;
    private bool termineMov;
    private Vector3 Origin;
    // Start is called before the first frame update
    void Start()
    {
      velocidad = 5f;
      debounce = false;
      termineMov = false;
      toRotate = pilar.transform.GetChild(1).gameObject;
      GetComponent<Renderer>().material.SetColor("_Color", Color.white);
      target = Quaternion.Euler(0,toRotate.transform.rotation.eulerAngles.y,0);
      lastRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
      Debug.DrawRay (transform.position, Vector3.up , Color.yellow);
      Debug.DrawRay (transform.position, Vector3.down, Color.yellow);
      if(termineMov){
        if(!debounce && (Physics.Raycast(transform.position,Vector3.up,10) || Physics.Raycast(transform.position,Vector3.down,0.5f)) ){
          Debug.Log("Entro");
          debounce = true;
          target = Quaternion.Euler(0,toRotate.transform.rotation.eulerAngles.y + 90f, 0);
          GetComponent<Renderer>().material.SetColor("_Color", Color.green);
          termineMov = false;
        }
        else{
          if(!Physics.Raycast(transform.position, Vector3.up,10) && !Physics.Raycast(transform.position,Vector3.down,0.5f))
            debounce = false;
        }
      }
      if(toRotate.transform.rotation != target){ //Si todavia no llego a destino
        toRotate.transform.rotation = Quaternion.Slerp(toRotate.transform.rotation,target,velocidad * Time.deltaTime);
      }
      else{ //Si ya llego a destino..... o esta muy cerca como para detectar una diferencia (Problema de precision)
        toRotate.transform.rotation = Quaternion.Euler(0,Mathf.Ceil(toRotate.transform.rotation.eulerAngles.y),0);//Lo llevo al numero entero mas cercano
        termineMov = true; //Termino el movimiento
        GetComponent<Renderer>().material.SetColor("_Color", Color.white);//Cambio color para indicar que ya se puede activar
      }
    }
    //
    // void OnTriggerEnter(Collider other){
    //   if(!debounce && termineMov){
    //     target = Quaternion.Euler(0,toRotate.transform.rotation.eulerAngles.y + 90f, 0);
    //     debounce = true;
    //     GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    //     termineMov = false;
    //   }
    // }
    //
    // void OnTriggerExit(Collider other){
    //   if(debounce){
    //     debounce = false;
    //   }
    // }
}
