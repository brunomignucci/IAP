using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gesto_toque : ADetector_gesto
{
    [SerializeField]
    GameObject go1, go2;
	[SerializeField]
    private static float distancia_optima = 0.02f;
	[SerializeField]
    private static float distancia_reset = 0.03f;
    private bool toque = false;//estado interno

    public override bool detect()
    {
		return (go1.activeInHierarchy && go2.activeInHierarchy) && detecto_proximidad();
	}

    private bool detecto_proximidad()
    {
		bool toReturn = false;
		float distancia = (go1.transform.position - go2.transform.position).magnitude;
		if (!toque) { 
			distancia = (go1.transform.position - go2.transform.position).magnitude;
			toque = distancia < distancia_optima;
			toReturn = toque;
        }
        else
        {
			if (distancia_reset < distancia)
			{
				toque = false;
				toReturn = false;
			}
		}
		return toReturn;

    }

	private void Start()
	{
		
	}
	private void Update()
	{
		
	}
}

