using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apagar_fuego : MonoBehaviour
{
    [SerializeField]
    private GameObject habilitador_proximo_puzzle;
    private int contador;
    private int cantidad_hijos;
    private int apague_todo = 0;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        cantidad_hijos = this.transform.childCount;
        //Debug.Log(cantidad_hijos);
    }
    public void apagar()
    {

        if (contador % 20 == 0 && contador / 20 < cantidad_hijos)
        {
            //Debug.Log("script_apagar");
            this.transform.GetChild(contador / 20).gameObject.SetActive(false);

        }
        contador++;
        if (apague_todo == 0 && contador / 20 >= cantidad_hijos)
        {
            //habilitador_proximo_puzzle.transform.GetChild(1).gameObject.SetActive(false);
            habilitador_proximo_puzzle.transform.Translate(-10.0f, 0.0f, 0.0f);
            apague_todo = 1;

        }

    }
}
