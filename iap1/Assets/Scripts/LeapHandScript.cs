using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapHandScript : MonoBehaviour
{

	[SerializeField]
	private GameObject wrist, palm;
	[SerializeField]
	private GameObject[] fingers;
	private int fingerSegments = 4;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    devuevlve un arreglo de posiciones de cada gameobject que compone la mano 
         
    */
	public Vector3[] getHandPositionsLocal()
	{
		Vector3[] toReturn = new Vector3[23];

		toReturn[0] = transform.localPosition;
		toReturn[1] = wrist.transform.localPosition;
		toReturn[2] = palm.transform.localPosition;
		for (int i = 0; i < fingers.Length; i++)
		{
			Transform curr = fingers[i].transform;

			for (int j = 0; j < fingerSegments; j++)
			{
				toReturn[i * 4 + j + 3] = curr.localPosition;
				if (curr.childCount > 0)
				{
					curr = curr.GetChild(0);
				}
			}
			
		}

		return toReturn;
	}

    /*
     devuelve un arreglo con las rotaciones de cada gameobject que compone las manos
     */
	public Quaternion[] getHandRotationsLocal()
	{
		Quaternion[] toReturn = new Quaternion[23];
		toReturn[0] = transform.localRotation;
		toReturn[1] = wrist.transform.localRotation;
		toReturn[2] = palm.transform.localRotation;
		for (int i = 0; i < fingers.Length; i++)
		{
			Transform curr = fingers[i].transform;

			for (int j = 0; j < fingerSegments; j++)
			{
				toReturn[i * 4 + j + 3] = curr.localRotation;
				if (curr.childCount > 0)
				{
					curr = curr.GetChild(0);
				}
			}
		}
		return toReturn;
	}
}
