using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class activar_menu : MonoBehaviour
{
    public GameObject cubo, esfera, flag_menu;

    Vector3 rot_inicial, rot;
    // Start is called before the first frame update
    void Start()
    {
        cubo.SetActive(false);
        esfera.SetActive(false);
        rot_inicial = this.transform.rotation.eulerAngles;
        //Debug.Log(rot_inicial.z);
        /*
         Flag menu es si esta activado es que tengo que dibujar cubos, sino esferas
         */
    }

    // Update is called once per frame
    void Update()
    {
        rot = this.transform.rotation.eulerAngles;
        float cor_x = rot.x;
        float cor_y = rot.y;
        float cor_z = rot.z;
        //Debug.Log("x"+cor_x);
        //Debug.Log("y"+cor_y);
        //Debug.Log("z"+cor_z);
        if (//cor_x - rot_inicial.x > 120)// &&
             cor_x < 50)
        {
            cubo.SetActive(true);
            esfera.SetActive(true);
            //Debug.Log("activo menu");
        }
        else
        {
            cubo.SetActive(false);
            esfera.SetActive(false);
        }
    }
}
