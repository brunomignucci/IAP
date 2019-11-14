using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flotante : MonoBehaviour
{
    private int cont;
    private bool subir;
    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        subir = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cont != 1000)
        {
            cont++;
            if (subir) {
                this.transform.Translate(0, 0.008f, 0);
                this.transform.Rotate(0, 0.19f, 0);
            }
            else {
                this.transform.Translate(0, -0.008f, 0);
                this.transform.Rotate(0, -0.19f, 0);
            }
        }
        else {
            cont = 0;
            subir = !subir;
        }
    }
}
