using UnityEngine;
using System.Collections;


public class gesto_tecla : ADetector_gesto
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
        if (Input.GetKeyDown(KeyCode.W)) {
            toReturn = true;
        }
		return toReturn;

      }
}

