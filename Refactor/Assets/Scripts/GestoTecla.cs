using UnityEngine;
using System.Collections;


public class GestoTecla : ADetectorGesto
{
	[SerializeField]
	private KeyCode key;

    public override bool detect()
    {
        return detecto_tecla();
    }

    private bool detecto_tecla()
    {
		return Input.GetKey(key);
    }

	private void Start()
	{

	}
	private void Update()
	{

	}
}
