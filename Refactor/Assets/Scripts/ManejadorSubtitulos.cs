using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManejadorSubtitulos: MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField]
    GameObject flag, sub_no_puente;

    public GameObject[] tagueados_no_puente,tagueados_flag_puente;


    void start()
    {
        Debug.Log("Hay mas de un sub no puente");

        tagueados_flag_puente = GameObject.FindGameObjectsWithTag("PASOPUENTE");
        flag = tagueados_flag_puente[0];

    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "COLLSUBNOPUENTE") 
        {
            
            //sub_no_puente = tagueados_no_puente[0];
            Debug.Log("entre en EL collider");
            sub_no_puente.SetActive(true);
            //if (flag.activeSelf)
            //{
            //    sub_no_puente.SetActive(true);
            //}
        }
    }

    private void OnTriggerExit(Collider collision)
    {
       
        if (collision.gameObject.tag == "COLLSUBNOPUENTE")
        {
            Debug.Log("ME FUI DEL COLLIDER");
            sub_no_puente.SetActive(false);
        }
        
    }


}
