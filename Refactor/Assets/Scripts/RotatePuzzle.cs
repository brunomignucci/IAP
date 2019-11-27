using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
public class RotatePuzzle : NetworkBehaviour
{
    public GameObject pilar;
    private GameObject toRotate;
    private bool debounce;
    private float velocidad;
    private Quaternion target;
    private float lastRotation;
    private bool termineMov;
    private bool flagRotacion;
    private Vector3 Origin;
    private bool captureRotacionTarget;
    private Quaternion rotacionTarget,rotacionActual;
    // Start is called before the first frame update
    void Start()
    {
        if (!isServer)
        {
            return;
        }
        flagRotacion = false;
        captureRotacionTarget = false;
      velocidad = 5f;
      debounce = false;
      termineMov = false;
      toRotate = pilar.transform.GetChild(1).gameObject;
      //GetComponent<Renderer>().material.SetColor("_Color", Color.white);
      GetComponent<SpawnableObject>().ChangeColor(Color.white);
      target = Quaternion.Euler(0,toRotate.transform.localRotation.eulerAngles.y,0);
      lastRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
        {
            return;
        }
        Debug.DrawRay (transform.position, Vector3.up , Color.yellow);

        if (!captureRotacionTarget) // si no estoy rotando
        {
            if ((Physics.Raycast(transform.position, Vector3.up, 2)))//si pase la mano por encima
            {
                captureRotacionTarget = true;
                flagRotacion = true;
                rotacionTarget = Quaternion.Euler(0, 90*((toRotate.transform.localRotation.eulerAngles.y + 90.0f)/90), 0);//intento forzar multiplos de 90
                GetComponent<SpawnableObject>().ChangeColor(Color.green);
            }
        }
        else // roto hasta alcanzar el target
        {             
            rotacionActual = toRotate.transform.localRotation;
            if (Math.Abs(rotacionActual.eulerAngles.y- rotacionTarget.eulerAngles.y)>0.00001f)// si todavia no rote lo suficiente
            {
                toRotate.transform.localRotation = Quaternion.Slerp(rotacionActual,
                    rotacionTarget, velocidad * Time.deltaTime);// le mande un 10 para que sea mas rapido ie menos veces
                Debug.Log("estoy rotando");
            }
            else
            {// si es lo suficientemente igual
                if (flagRotacion) // si vengo de rotar
                {
                    GetComponent<SpawnableObject>().ChangeColor(Color.white);// le vuelvo a poner el color
                    captureRotacionTarget = false;
                    flagRotacion = false;
                }                 
            }
        }
        /*
        //Debug.DrawRay (transform.position, Vector3.down, Color.yellow);
        if (termineMov)
        {
            //Debug.Log("Termine y puedo entrar");
            if (!debounce && (Physics.Raycast(transform.position, Vector3.up, 2)))
            {
                //Debug.Log("Entro");
                debounce = true;
                target = Quaternion.Euler(0, toRotate.transform.localRotation.eulerAngles.y + 90f, 0);
                //GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                GetComponent<SpawnableObject>().ChangeColor(Color.green);
                termineMov = false;
                flagRotacion = false;
            }
            else
            {
                if (!Physics.Raycast(transform.position, Vector3.up, 2))
                    debounce = false;
            }
        }
        else 
        {
            if (toRotate.transform.localRotation != target && !termineMov)
            { //Si todavia no llego a destino
              //Debug.Log(toRotate.transform.localRotation.eulerAngles);
                              
                termineMov = true;                
                continuarRotando = true;
                if (continuarRotando)
                {
                    toRotate.transform.localRotation = Quaternion.Slerp(toRotate.transform.localRotation, target, velocidad * Time.deltaTime);
                }
                //Debug.Log("Sigo Moviendo");
            }
            else
            { //Si ya llego a destino..... o esta muy cerca como para detectar una diferencia (Problema de precision)
                if (continuarRotando) 
                {
                    toRotate.transform.localRotation = Quaternion.Euler(0, Mathf.Ceil(toRotate.transform.localRotation.eulerAngles.y), 0);//Lo llevo al numero entero mas cercano
                    GetComponent<SpawnableObject>().ChangeColor(Color.white);
                }                
                continuarRotando = false;
                termineMov = true; //Termino el movimiento
                                   //GetComponent<Renderer>().material.SetColor("_Color", Color.white);//Cambio color para indicar que ya se puede activar
                
            }
        }*/

      
    }
}
