using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPuzzlePickFar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player,portal1,portal2,portal3,pos_inicial_step2,pos_inicial_step3,pos_final,detector1,detector2,detector3;

    Vector3 pos_inicial;

    private bool activar_portal1,activar_portal2,activar_portal3;
    private bool step1, step2, step3;
    void Start()
    {
        activar_portal1 = false;
        activar_portal2 = false;
        activar_portal3 = false;
        step1 = false;
        step2 = false;
        step3 = false;
        pos_inicial = portal1.transform.position; // para por si se cae el player 

    }

    // Update is called once per frame
    void Update()
    {
        if (!step1) 
        {            
            if (!activar_portal1 && detector1.activeSelf)
            {
                portal1.SetActive(true);
                activar_portal1 = true;
                GameObject[] players = GameObject.FindGameObjectsWithTag("PLAYER");
                if (players.Length > 1) { Debug.Log("hay muchos players"); }
                player = players[0];
            }
            if (((player.transform.position - portal1.transform.GetChild(0).position).magnitude) < 1.2f)
            {
                Debug.Log("toque el portal 1");
                player.transform.position = pos_inicial_step2.transform.position;               
                step1 = true;
            }
        }
        if (!step2)
        {
            if (!activar_portal2 && detector2.activeSelf)
            {
                portal2.SetActive(true);
                activar_portal2 = true;
            }
            if (((player.transform.position - portal2.transform.GetChild(0).position).magnitude) < 1.2f)
            {
                Debug.Log("toque el portal 2");
                player.transform.position = pos_inicial_step3.transform.position;
                step2 = true;
            }
        }
        if (!step3)
        {
            if (!activar_portal3 && detector3.activeSelf)
            {
                portal3.SetActive(true);
                activar_portal3 = true;
            }
            if (((player.transform.position - portal2.transform.GetChild(0).position).magnitude) < 1.2f)
            {
                Debug.Log("toque el portal 3");
                player.transform.position = pos_final.transform.position;
                step3 = true;
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PORTAL1") {
            // si toco el tag portal1 me voy al step2
            //Debug.Log("toque el portal 1");
            
            //player.transform.position = pos_inicial_step2.transform.position;
        }
        if (other.tag == "PORTAL2")
        {
            player.transform.position = pos_inicial_step3.transform.position;
        }
        if (other.tag == "PORTAL3")
        {
            player.transform.position = pos_final.transform.position;
        }

    }
}
