using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionadorAdelante : AAccionador
{
    public override void accionar()
    {
        accionar_adelante();
    }

    private void accionar_adelante()
    {
        transform.root.GetComponent<Server>().mover_adelante_leap();
    }
	private void Start()
	{
		
	}
	private void Update()
	{
		
	}
}
