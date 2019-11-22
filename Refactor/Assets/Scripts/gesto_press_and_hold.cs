using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gesto_press_and_hold : ADetector_gesto
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
		float distancia = (go1.transform.position - go2.transform.position).magnitude;
		if (!toque)
		{
			distancia = (go1.transform.position - go2.transform.position).magnitude;
			toque = distancia < distancia_optima;
		}
		else
		{
			toque = !(distancia_reset < distancia);
		}
		return toque;

	}
	private void Start()
	{
		
	}
	private void Update()
	{
		
	}
}