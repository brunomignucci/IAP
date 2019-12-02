using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activadorCasaRara : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject casa;
	public GameObject casarara;

	private void OnTriggerEnter(Collider other)
	{
		toggleActive(other);
	}
	void toggleActive(Collider other)
	{
		if (other.tag=="PLAYER")
		{
			casa.SetActive(!casa.activeSelf);
			casarara.SetActive(!casarara.activeSelf);
		}
		
	}
}
