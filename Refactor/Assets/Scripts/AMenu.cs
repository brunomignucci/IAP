using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMenu : MonoBehaviour
{
	protected AMenu_Entry[] entries;
	protected AMenu_Entry selected;

	public abstract void SelectEntry(AMenu_Entry entry);

}
