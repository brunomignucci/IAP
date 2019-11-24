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
        cantidad_hijos = 10;
        //Debug.Log(cantidad_hijos);
    }
    public void apagar(GameObject fuego_a_apagar)
    {
        contador++;
        //Debug.Log("scrip afuera del if");
        
        if (contador % 20 == 0 && contador / 20 <= cantidad_hijos)
        {
            //Debug.Log("script_apagar");
            Debug.Log(contador);
            fuego_a_apagar.transform.GetChild(0).gameObject.SetActive(false);

        }
        

        //Debug.Log(contador);
        if (apague_todo == 0 && contador / 20 == cantidad_hijos)
        {
            //habilitador_proximo_puzzle.transform.GetChild(1).gameObject.SetActive(false);
            habilitador_proximo_puzzle.transform.Translate(-10.0f, 0.0f, 0.0f);
            apague_todo = 1;

        }

    }
}
