using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador_puente : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject puente,collider_paso;
    GameObject p0, p1, p2, p3, p4;
    bool habilitar_paso;

    void Start()
    {
        p0 = puente.transform.GetChild(0).gameObject;
        p1 = puente.transform.GetChild(1).gameObject;
        p2 = puente.transform.GetChild(2).gameObject;
        p3 = puente.transform.GetChild(3).gameObject;
        p4 = puente.transform.GetChild(4).gameObject;
        habilitar_paso = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (habilitar_paso) {
            //desactivar collider que impide el paso
            collider_paso.SetActive(false);
        }
        //if (p0.activeSelf && p1.activeSelf && p2.activeSelf && p3.activeSelf && p4.activeSelf) {
        //    habilitar_paso = true;
        //}
        if (p0.activeSelf && p1.activeSelf) { 
            habilitar_paso = true;
        }
    }
}
