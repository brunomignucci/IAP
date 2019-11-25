using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMenu_Entry : ADetectorGesto
{
	public abstract void select();
	public abstract void deselect();
}