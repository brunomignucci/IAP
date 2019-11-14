using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cubo, esfera;
    public GameObject menu_flag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos_indice_der1 = this.transform.position;
        Vector3 pos_cubo;
        Vector3 pos_esfera;
        if (cubo != null)
        {
            pos_cubo = cubo.transform.position;
            float distancia_indice_cubo = (pos_indice_der1 - pos_cubo).magnitude;
            if (distancia_indice_cubo < 0.03)
            {
                Debug.Log("tengo que dibujar cubos");
                menu_flag.SetActive(false);
				cubo.GetComponent<Renderer>().material.color = Color.green;
				esfera.GetComponent<Renderer>().material.color = Color.gray;

			}
		}
        if (esfera != null)
        {
            pos_esfera = esfera.transform.position;
            float distancia_indice_esfera = (pos_indice_der1 - pos_esfera).magnitude;
            if (distancia_indice_esfera < 0.03)
            {
                Debug.Log("Tengo que dibujar esferas");
                menu_flag.SetActive(true);
				cubo.GetComponent<Renderer>().material.color = Color.gray;
				esfera.GetComponent<Renderer>().material.color = Color.green;
			}
        }
       
    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "CUBO")
        {
            Debug.Log("tengo que dibujar cubos");
            menu_flag.SetActive(false);

        }
        if (other.tag == "ESFERA") {
            Debug.Log("Tengo que dibujar esferas");
            menu_flag.SetActive(true);
        }

    }
}
