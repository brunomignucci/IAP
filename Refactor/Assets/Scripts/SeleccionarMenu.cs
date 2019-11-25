using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarMenu : AAccionador
{

	[SerializeField]
	private AMenu_Entry menuentry;
	[SerializeField]
	private GameObject menu_flag;

	public override void accionar()
	{
		//menuentry.select();
		Debug.Log("tengo que dibujar cubos");
		menu_flag.SetActive(false);
	}
}
