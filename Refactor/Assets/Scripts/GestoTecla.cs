using UnityEngine;
using System.Collections;


public class GestoTecla : ADetector_gesto
{
    [SerializeField]
    string tecla;

    public override bool detect()
    {
        return detecto_tecla();
    }

    private bool detecto_tecla()
    {
		bool toReturn = false;
        if (Input.GetKeyDown(KeyCode.Z)) {
            toReturn = true;
        }
		return toReturn;

      }

	private void Start()
	{

	}
	private void Update()
	{

	}
}
