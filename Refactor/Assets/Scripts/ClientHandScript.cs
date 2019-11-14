using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandScript : MonoBehaviour
{
	[SerializeField]
	private GameObject wrist,palm;
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

	public void UpdateHand(Vector3[] newPositions, Quaternion[] newRotations)
	{
		//actualizo la mano
		transform.localPosition = newPositions[0];
		transform.localRotation = newRotations[0];
		//actualizo munieca
		wrist.transform.localPosition = newPositions[1];
		wrist.transform.localRotation = newRotations[1];
		//actualizo palma
		palm.transform.localPosition = newPositions[2];
		palm.transform.localRotation = newRotations[2];
		//actualizo dedos
		for(int i = 0; i < fingers.Length; i++)
		{
			updateFinger(fingers[i], new System.ArraySegment<Vector3>(newPositions, i* fingerSegments + 3, fingerSegments), new System.ArraySegment<Quaternion>(newRotations, i* fingerSegments + 3, fingerSegments));
		}

	}
	private void updateFinger(GameObject fingerRoot, IList<Vector3> newPositions, IList<Quaternion> newRotations)
	{
		Transform curr = fingerRoot.transform;
		bool done = false;
		int i = 0;
		while(!done)
		{
			if(curr.childCount > 0)
			{ 
				curr.localPosition = newPositions[i];
				curr.localRotation = newRotations[i];
				curr = curr.GetChild(0);
				i++;
			}
			else
			{
				done = true;
			}

		}
	}
	
}
