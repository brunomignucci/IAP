using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apagar_fuego : MonoBehaviour
{
    private int contador;
    private int cantidad_hijos;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        cantidad_hijos = this.transform.childCount;
        //Debug.Log(cantidad_hijos);
    }
    public void apagar()
    {
        
        if(contador%20==0 && contador/20<cantidad_hijos)
        {
            //Debug.Log("script_apagar");
            this.transform.GetChild(contador / 20).gameObject.SetActive(false);
        }
        contador++;

    }
}
