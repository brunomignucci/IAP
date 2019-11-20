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
	private Camera cam;
	private Plane plano;
	private RaycastHit hitInfo;
	private GameObject pickedObject;
	private Vector3 screenPoint;
	private Vector3 offset;

    public override void accionar()
    {
        accionar_pick();
    }

    public void accionar_pick()
	{
		plano.Set3Points(planepoint1.transform.position, planepoint2.transform.position, planepoint3.transform.position);
		if(pickedObject != null)
		{
			pickedObject.transform.position = pickposref.transform.position;
		}

		if (Physics.Raycast(orig.transform.position, plano.normal, out hitInfo, raydist, layer))
		{
			if(pickedObject == null)
			{
				pickedObject = hitInfo.transform.gameObject;
				pickedObject.GetComponent<Rigidbody>().isKinematic = true;
				pickposref.transform.position = pickedObject.transform.position;
			}
		}
		else
		{
			if (pickedObject != null)
			{
				pickedObject.GetComponent<Rigidbody>().isKinematic = false;
				pickedObject = null;
			}
		}
		
    }

    void start()
	{
		plano.Set3Points(planepoint1.transform.position, planepoint2.transform.position, planepoint3.transform.position);
	}

	void Update()
	{
	}
}