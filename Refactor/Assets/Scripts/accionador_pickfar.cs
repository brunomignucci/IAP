using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class accionador_pickfar : AAccionador
{
    [SerializeField]
	private GameObject orig, planepoint1,planepoint2,planepoint3,pickposref;
	[SerializeField]
	private float rayDist,rayThickness;
	[SerializeField]
	private LayerMask layer;
	private Plane plano;
	private RaycastHit hitInfo;
	private GameObject pickedObject;
	private float pickedDist;
	private Vector3 center;

	public override void accionar()
    {
        accionar_pick();
		Debug.Log("PICK FAR");
    }

    public void accionar_pick()
	{
		plano.Set3Points(planepoint1.transform.position, planepoint2.transform.position, planepoint3.transform.position);
		center = Vector3.Lerp(Vector3.Lerp(planepoint1.transform.position, planepoint2.transform.position, 0.5f), planepoint3.transform.position, 0.5f);
		Debug.DrawRay(center, plano.normal * rayDist, Color.magenta);
		// Si no hay objeto pickeado, lanzamos un rayo para encontrar algun objeto pickeable
		if (pickedObject == null) {
			if (Physics.Raycast(center, plano.normal, out hitInfo, rayDist, layer))
			{
				pickedObject = hitInfo.transform.gameObject;
				pickedDist = (hitInfo.transform.position - center).magnitude;

			}
		}
		// Si habia un objeto pickeable, lanzamos una esfera para ver si sigue estando pickeado, y actualizamos su posicion
		else
		{
			//Si hiteamos algo, vemos si era el objeto que teniamos antes o uno nuevo
			RaycastHit[] hits = Physics.SphereCastAll(center, rayThickness, plano.normal, rayDist, layer);
			if (hits.Length > 0)
			{
				bool mismoobjeto = false;
				foreach(RaycastHit hit in hits)
				{
					if(hit.transform.gameObject == pickedObject)
					{
						mismoobjeto = true;
					}
				}
				if (!mismoobjeto) {

					if (Physics.Raycast(center, plano.normal, out hitInfo, rayDist, layer))
					{
						pickedObject = hitInfo.transform.gameObject;
						pickedDist = (hitInfo.transform.position - center).magnitude;

					}
					else
					{
						pickedObject = null;
						pickedDist = 0.0f;
					}
				}
				else
				{
					pickedObject.transform.position = center + plano.normal * pickedDist;
					pickedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				}

				//// Si es un objeto nuevo, actualizamos
				//if (hitInfo.transform.gameObject != pickedObject)
				//{
				//	pickedObject = hitInfo.transform.gameObject;
				//	pickedDist = (hitInfo.transform.position - center).magnitude;
				//}
				//// Si era el anterior, lo movemos para que siga el rayo
				//else
				//{
				//	pickedObject.transform.position = center + plano.normal * pickedDist;
				//	pickedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				//}
			}
			// Si no le pegamos a nada, soltamos el objeto pickeado
			else
			{
				pickedObject = null;
				pickedDist = 0.0f;
			}

		}


	}

	void start()
	{
		
	}

	private void update()
	{
	
	}
}