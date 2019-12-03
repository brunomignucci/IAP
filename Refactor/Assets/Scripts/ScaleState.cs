﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class ScaleState : State
{
  public GameObject referencia_posicion;
  private bool escalando = false;
  private float escala = 1f;
  private bool tipoEscalado = false;
  private int size = 0;
  private GameObject objeto;
  private NetworkInstanceId id;
  private GameObject lista;
  public GameObject camera;

  public void Start(){
    lista = GameObject.Find("/ListaObjetosCreados");
  }

  private void Update(){
    if(escalando){
      objeto.transform.position = referencia_posicion.transform.position + camera.transform.forward * 1.5f
       + new Vector3(0, 0.5f, 0);
			objeto.transform.localScale = new Vector3(escala,escala,escala) ;
      objeto.GetComponent<SpawnableObject>().ScaleObject(escala);
    //  Debug.Log(escala);
      if(!tipoEscalado){
		//escala += 0.01f;
		escala +=Time.deltaTime;
        if(escala >= 2f){

          tipoEscalado = true;
        }
      }
      else{
		//escala -= 0.01f;
		escala -= Time.deltaTime;
        if(escala <= 0.1f)
          tipoEscalado = false;
      }
    }
  }

  public override void initialize(){
    Debug.Log("Inicializando estado de escalado");
    escalando = true;
    tipoEscalado = false;
    escala = 0.2f;
    size = lista.transform.childCount;
    objeto = lista.transform.GetChild(size - 1).gameObject;
    id = objeto.GetComponent<NetworkIdentity>().netId;
  }

  public override void alert(CreationStateContext ctx){
    Debug.Log("Escalando");
    escalando = false;
    objeto.GetComponent<Rigidbody>().isKinematic = false;
        objeto.GetComponent<Collider>().enabled = true;
        objeto.GetComponent<Rigidbody>().detectCollisions = true;
        //objeto.GetComponent<gravityPrefab>().enabled = true;
        ctx.setState(next);
  }
}
