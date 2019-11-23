using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

	private Text TextHUD;

	public override void accionar()
	{
		TextHUD.text = prefab.tag;
		menu.SelectEntry(menuentry);
		transform.root.GetComponent<Server>().SetSelectedHandMenuEntry(menuentry.transform.GetSiblingIndex());

		if (toCreate.transform.childCount > 0)
		{
			Destroy(toCreate.transform.GetChild(0).gameObject);
		}
		Instantiate(prefab, toCreate.transform).GetComponent<MeshRenderer>().enabled = false;
	}

	void Start(){
		TextHUD = GameObject.Find("ObjetoACrear").GetComponent<Text>();
	}
}
