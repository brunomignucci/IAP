using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAgua : MonoBehaviour
{
    [SerializeField]
    private GameObject indice_izq, indice_der, pulgar,particulas;

    private Plane plano_forward;

    public void ActivarAgua()
    {
        
        if(particulas.activeSelf==false)
        {
            //si las particulas estan desactivadas las activo
            particulas.SetActive(true);
        }
        plano_forward.Set3Points(indice_izq.transform.position, pulgar.transform.position, indice_der.transform.position);
        particulas.gameObject.transform.GetChild(0).position = pulgar.transform.position;
        particulas.gameObject.transform.GetChild(0).forward = plano_forward.normal;

        Ray rayo = new Ray(pulgar.transform.position, plano_forward.normal);
        RaycastHit hit;
        if (Physics.Raycast(rayo, out hit, 10.0f))
        {
            if(hit.transform.parent!=null && hit.transform.parent.tag=="ARBOLES") GameObject.Find("Fuego").GetComponent<apagar_fuego>().apagar();
            //Debug.Log("Apagando");
        }
        

        //acá habria que hacer la lógica de que collidee el bosque

        //actualizo vectores de posicion y 
    }
    public void DesactivarAgua()
    {
        if (particulas.activeSelf == true)
        {
            //si las particulas estan activas las desactivo
            particulas.SetActive(false);
        }

    }
}
