using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BuildState : State
{
  private GameObject parent;
  public GameObject referencia_posicion;
  public GameObject menu_flag;
  public GameObject cubo,esfera;
  private GameObject newObject;

  public void Start(){
    parent = GameObject.Find("/ListaObjetosCreados");
  }

  public override void alert(CreationStateContext ctx){
    Debug.Log("Construyendo");
    if(!menu_flag.activeSelf)
      newObject = Instantiate(cubo);
    else
      newObject = Instantiate(esfera);
    Color colorRandom = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
    newObject.GetComponent<Renderer>().material.SetColor("_Color", colorRandom);
    NetworkServer.Spawn(newObject);
    newObject.transform.position = referencia_posicion.transform.position;
    newObject.transform.SetParent(parent.transform);
    ctx.setState(next);
  }

  public override void initialize(){
    Debug.Log("Inicializando estado Build");
  }
}
