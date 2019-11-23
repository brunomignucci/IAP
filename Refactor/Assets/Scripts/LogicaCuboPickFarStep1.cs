using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCuboPickFarStep1 : MonoBehaviour
{
    [SerializeField]
    GameObject detector;
    private int cont; 
    private Vector3 pos_inicial;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        pos_inicial = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f) { // por si se cae
            transform.position = pos_inicial;
            rb.velocity = new Vector3(0,0,0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DETECTOR1") {
            cont++;
            if (cont > 250) { // este codigo hay que agregar a los detectores del escenario 1
                detector.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        cont = 0;
    }
}
