using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCapturadorRoca : MonoBehaviour
{
    // Start is called before the first frame update
    private int cont;
    [SerializeField]
    GameObject parte_puente_cubo;
    Light luz;
    void Start()
    {
        cont = 0;
        luz = this.transform.GetChild(0).gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ROCA")
        {
            cont++;
            if (cont == 10)
            {
                parte_puente_cubo.SetActive(true);
                luz.color = Color.green;
            }
        }
        else
        {
            cont = 0; if (other.tag != "UNDELETEABLE" || other.tag != "PLAYER")
            {
                Destroy(other.gameObject);
            }

        }
    }
}
