using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : AMenu
{
	public override void SelectEntry(AMenu_Entry entry)
	{
		if(selected != null)
		{
			selected.deselect();
		}	
		selected = entry;
		selected.select();
	}

	// Start is called before the first frame update
	void Start()
    {
		entries = GetComponentsInChildren<HandMenuEntry>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public AMenu_Entry GetEntryAt(int i)
	{
		return entries[i];
	}

}
