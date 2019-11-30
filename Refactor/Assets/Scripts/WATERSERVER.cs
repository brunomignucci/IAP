using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class WATERSERVER : NetworkBehaviour
{


    public GameObject flag,aguaServidor,indice_izq_leap,pulgar_leap,indice_der_leap;
    private GameObject dedo1,dedo2;
    private GameObject agua;
    private GameObject[] players;
    private bool estado,encontre_agua;

    private Plane plano_forward;

    

    // Start is called before the first frame update
    void Start()
    {
        estado = false;
        encontre_agua = false;
    }

    private void aplicarRotacionAgua()
    {
        //calculo la rotacion segun los 3 puntos
        // le aplico la rotacion

        plano_forward.Set3Points(indice_izq_leap.transform.position, pulgar_leap.transform.position, indice_der_leap.transform.position);
        agua.gameObject.transform.GetChild(0).forward = plano_forward.normal;
        aguaServidor.gameObject.transform.GetChild(0).forward = plano_forward.normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
        {
            return;
        }
        //si soy el server
        if (!encontre_agua) // tengo que encontrar el agua
        {
            players = GameObject.FindGameObjectsWithTag("PLAYER");            
            if (players.Length>0) 
            {
                encontre_agua = true;
                agua = players[0].transform.GetChild(7).gameObject;
                Debug.Log("Encontre el agua");
                aguaServidor.transform.SetParent(agua.transform);
                dedo1 = players[0].transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
                dedo2 = players[0].transform.GetChild(2).GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
                indice_izq_leap= players[0].transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
                indice_der_leap = players[0].transform.GetChild(2).GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
                pulgar_leap = dedo1;
            }
        }
        if (aguaServidor.activeSelf)
        {
            aguaServidor.transform.position = agua.transform.position;
            aplicarRotacionAgua();
            //aguaServidor.transform.forward = agua.transform.forward;
        }
        if (encontre_agua && Math.Abs((dedo1.transform.position - dedo2.transform.position).magnitude) < 0.02f)
        {
            //activo el agu a
           
            aguaServidor.SetActive(true);

            agua.SetActive(true);
            estado = true;
        }
        else
        {
            if (encontre_agua && aguaServidor.activeSelf)
            {
                agua.SetActive(false);
                aguaServidor.SetActive(false);
                estado = false;
            }            
        }
    }
}
