using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionadorAguaApagar : AAccionador
{
	//[SerializeField]
	//GameObject particulas;
	[SerializeField]
	private GameObject serverCamera;

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
		serverCamera.GetComponent<ScriptAgua>().DesactivarAgua();
        //Debug.Log("desactive");
        /*
        if (particulas.activeSelf == true)
        {
            Debug.Log("desactive");
            particulas.SetActive(false);

        }
        */
    }
	private void Start()
	{
		
	}
	private void Update()
	{
		
	}

}
