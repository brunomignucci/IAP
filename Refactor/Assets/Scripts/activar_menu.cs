using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class activar_menu : MonoBehaviour
{
    //public GameObject cubo, esfera;
	[SerializeField]
	private GameObject a, b, c;
	[SerializeField]
	private GameObject camara;
	[SerializeField]
	private GameObject menu;
	private Plane plano;

    // Start is called before the first frame update
    void Start()
    {
		//cubo.SetActive(false);
		//esfera.SetActive(false);
		menu.SetActive(false);
		plano.Set3Points(a.transform.position, b.transform.position, c.transform.position);
	}

    // Update is called once per frame
    void Update()
    {
		plano.Set3Points(a.transform.position, b.transform.position, c.transform.position);
		if (plano.GetSide(camara.transform.position) )
		{
			menu.SetActive(true);
			transform.root.GetComponent<Server>().SetHandMenuActive(true);

		}
		//else
		//{

			if (!plano.GetSide(camara.transform.position) )
			{
				menu.SetActive(false);
				transform.root.GetComponent<Server>().SetHandMenuActive(false);
			}

		//	}
	}
}
