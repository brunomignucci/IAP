using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu_flag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
