using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
	private int state;
	GameObject obj;
	[SerializeField]
	private GameObject[] shapes;
	private int selector;

	private void Start()
	{
		state = 0;
	}

	public void startCreating()
	{
		if (state == 0)
		{
			obj = Instantiate(shapes[selector]);
			state = 1;
		}
	}

	public void scaling(Vector3 scale)
	{
		if(state == 1)
		{
			obj.transform.localScale = scale;
		}
	}

	public GameObject finish()
	{
		if(state == 1)
		{
			state = 0;
		}
		return obj;
	}

    public GameObject getPreview()
    {
        return obj;
    }
    public void setShape(int sel)
    {
        selector = sel;
    }
	
}
