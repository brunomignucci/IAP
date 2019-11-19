using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seleccionar_menuentry : AAccionador
{

	[SerializeField]
	private AMenu_Entry menuentry;
	[SerializeField]
	private AMenu menu;
	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private GameObject toCreate;

	public override void accionar()
	{
		menu.SelectEntry(menuentry);
		transform.root.GetComponent<Server>().SetSelectedHandMenuEntry(menuentry.transform.GetSiblingIndex());

		if (toCreate.transform.childCount > 0)
		{
			Destroy(toCreate.transform.GetChild(0).gameObject);
		}
		Instantiate(prefab, toCreate.transform);
	}
}
