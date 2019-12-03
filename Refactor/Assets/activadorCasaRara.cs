using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activadorCasaRara : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject casa;
	public GameObject casarara;
	private MeshRenderer[] meshRenderers;
	private Light[] lights;

	private void Start()
	{
		meshRenderers = casa.GetComponentsInChildren<MeshRenderer>();

		lights = casa.GetComponentsInChildren<Light>();
	}
	private void OnTriggerEnter(Collider other)
	{
		toggleActive(other);
	}
	void toggleActive(Collider other)
	{
		if (other.tag == "PLAYER")
		{
			foreach (MeshRenderer meshrenderer in meshRenderers)
			{
				meshrenderer.enabled = true;
			}
			foreach (Light light in lights)
			{
				light.enabled = true;

			}

		}
	}
}
