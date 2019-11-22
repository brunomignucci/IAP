using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestor : MonoBehaviour
{

    [SerializeField]
    private ADetector_gesto detector_gest;
    [SerializeField]
    private AAccionador accionador;
    [SerializeField]
    
    // Start is called before the first frame update
    void Start()
    {
        detector_gest = GetComponent<ADetector_gesto>();
        accionador = GetComponent<AAccionador>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detector_gest.detect())
            accionador.accionar();
    }
}
