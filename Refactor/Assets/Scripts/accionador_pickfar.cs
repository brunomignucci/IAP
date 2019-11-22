using UnityEngine;
using System.Collections;

public class accionador_pickfar : AAccionador
{
    [SerializeField]
	private GameObject orig, planepoint1,planepoint2,planepoint3,pickposref;
	[SerializeField]
	private float raydist;
	[SerializeField]
	private LayerMask layer;
	[SerializeField]
	private float rayThickness = 0.05f;
	[SerializeField]
	private Plane plano;
	private RaycastHit hitInfo;
	private GameObject pickedObject;
	private Vector3 zeroVelocity = new Vector3(0, 0, 0);

    public override void accionar()
    {
        accionar_pick();
		Debug.Log("PICK FAR");
    }

    public void accionar_pick()
	{
		// Si no hay objeto pickeado, lanzamos un rayo para encontrar algun objeto pickeable
		if (pickedObject == null) {
			plano.Set3Points(planepoint1.transform.position, planepoint2.transform.position, planepoint3.transform.position);
			if (Physics.Raycast(orig.transform.position, plano.normal, out hitInfo, raydist, layer))
			{
				pickedObject = hitInfo.transform.gameObject;
				pickposref.transform.position = pickedObject.transform.position;
			}
		}
		// Si habia un objeto pickeable, actualizamos su posicion
		else
		{
			pickedObject.transform.position = pickposref.transform.position;
			pickedObject.GetComponent<Rigidbody>().velocity = zeroVelocity;
		}


	}

	void start()
	{
		
	}

	private void FixedUpdate()
	{
		// Vemos si el objeto pickeado sigue siendo apuntado por el raycast
		if (pickedObject != null) 
		{ 
			if (Physics.SphereCast(orig.transform.position, rayThickness, plano.normal, out hitInfo, raydist, layer))
			{
				if (pickedObject != hitInfo.transform.gameObject)
				{
					if (! Physics.Raycast(orig.transform.position, plano.normal, out hitInfo, raydist, layer))
					{
						pickedObject = null;
					}
				}
			}
			else
			{
				pickedObject = null;
			}
		}
	}
}