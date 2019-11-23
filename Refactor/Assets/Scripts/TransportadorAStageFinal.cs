using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportadorAStageFinal : MonoBehaviour
{   [SerializeField]
    private GameObject posicion_step1,portal1;
    private GameObject player;
    private bool step1,encontrar_player;
    public GameObject Trigger;
    private ActivarPortal codigo;


    void Start(){

      encontrar_player=true;
      step1=true;
      codigo = Trigger.GetComponent<ActivarPortal>();


    }

    void Update(){

      if(encontrar_player && codigo.activado){
        GameObject[] players = GameObject.FindGameObjectsWithTag("PLAYER");

        player = players[0];
        Debug.Log("Encontre jugador");
        encontrar_player = false;
        step1=false;
      }

      if(codigo.activado){
      if(!step1){
        Vector3 pos_player=player.transform.position;
        Vector3 pos_portal=portal1.transform.GetChild(0).position;
        if (((pos_player- pos_portal).magnitude) < 1.2f)
        {
            Debug.Log("toque el portal cementerio");
            player.transform.position = posicion_step1.transform.position;
            step1 = true;
        }
      }
}
    }



}
