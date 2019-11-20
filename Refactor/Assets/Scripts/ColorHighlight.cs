using UnityEngine;
using System.Collections;
public class ColorHighlight : MonoBehaviour
{
	[SerializeField]
	private float distanceToSee;
	[SerializeField]
	private Color highlightColor;
	Material originalMaterial, tempMaterial;
	Renderer rend = null;
	[SerializeField]
	private LayerMask layer;
	[SerializeField]
	private GameObject planepoint1,planepoint2,planepoint3;
	private Plane plano;

	void Start()
	{
		//highlightColor = Color.green;
		plano.Set3Points(planepoint1.transform.position, planepoint2.transform.position, planepoint3.transform.position);
	}


	void Update()
	{
		plano.Set3Points(planepoint1.transform.position, planepoint2.transform.position, planepoint3.transform.position);

		RaycastHit hitInfo;
		Renderer currRend;

		Debug.DrawRay(this.transform.position, plano.normal * distanceToSee, Color.magenta); 

		if (Physics.Raycast(this.transform.position, plano.normal, out hitInfo, distanceToSee,layer))
		{
			currRend = hitInfo.collider.gameObject.GetComponent<Renderer>();

			if (currRend == rend)
				return;

			if (currRend && currRend != rend)
			{
				if (rend)
				{
					rend.sharedMaterial = originalMaterial;
				}

			}

			if (currRend)
				rend = currRend;
			else
				return;

			originalMaterial = rend.sharedMaterial;

			tempMaterial = new Material(originalMaterial);
			rend.material = tempMaterial;
			rend.material.color = highlightColor;
		}
		else
		{
			if (rend)
			{
				rend.sharedMaterial = originalMaterial;
				rend = null;
			}
		}
	}
}