//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GestoPressing : ADetector_gesto
//{
//	[SerializeField]
//	private GameObject go1, go2;

//	private static float distancia_optima = 0.03f;
//	private bool state = false;//estado interno

//	public override bool detect()
//	{
//		return detecto_proximidad();
//	}

//	private bool detecto_proximidad()
//	{
//		Vector3 obj1, obj2;
//		float distancia;

//		obj1 = transform.position;
//		obj2 = objeto.transform.position;
//		distancia = (obj1 - obj2).magnitude;
//		if (distancia < distancia_optima) return true;
//		else return false;

//	}

//}