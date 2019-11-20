using UnityEngine;
using System.Collections;

public class accionador_pickfar : AAccionador
{
    [SerializeField]
	private GameObject orig, planepoint1,planepoint2,planepoint3;
	[SerializeField]
	private float raydist;
	[SerializeField]
	private LayerMask layer;
	private Plane plano;
	private RaycastHit hitInfo;
	private GameObject pickedObject;

    public override void accionar()
    {
        accionar_pick();
    }

    public void accionar_pick()
	{
        if(Physics.Raycast(orig.transform.position,plano.normal,out hitInfo, raydist,layer))
		{
			hitInfo.transform.position = hitInfo.point;
		}
    }

    void start()
	{
		plano.Set3Points(planepoint1.transform.position, planepoint2.transform.position, planepoint3.transform.position);
	}

	void Update()
	{
		plano.Set3Points(planepoint1.transform.position, planepoint2.transform.position, planepoint3.transform.position);
	}
}