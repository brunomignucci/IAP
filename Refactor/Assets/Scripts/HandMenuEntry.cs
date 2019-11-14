using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenuEntry : AMenu_Entry
{
	private bool selected;
	[SerializeField]
	GameObject visual;

	public override void select()
	{
		selected = true;
		GetComponent<Renderer>().material.color = Color.green;
	}
	public override void deselect()
	{
		selected = false;
		GetComponent<Renderer>().material.color = Color.gray;
	}

	public override bool detect()
	{
		return selected;
	}
}
