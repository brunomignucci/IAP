using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accionador_agua_apagar : AAccionador
{
    [SerializeField]
    //GameObject particulas;

    //private bool activo = false;
    public override void accionar()
    {
        accionar_agua_apagar();
    }

    private void accionar_agua_apagar()
    {
        /*
         * */
        transform.root.GetComponent<Server>().SetWaterEnable(false);
        //Debug.Log("desactive");
        /*
        if (particulas.activeSelf == true)
        {
            Debug.Log("desactive");
            particulas.SetActive(false);

        }
        */
    }
    
}
