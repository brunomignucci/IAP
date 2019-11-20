using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finalizador : MonoBehaviour
{
    private bool abrir;
    public GameObject gate1,gate2;
    private float velocidad;
    private float tresholdHeight;
    // Start is called before the first frame update
    void Start()
    {
      velocidad = 2f;
      tresholdHeight = -6f;
      abrir = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(abrir){
        if(gate1.transform.position.y > tresholdHeight){ //Move Gate1
          gate1.transform.position = new Vector3(gate1.transform.position.x, gate1.transform.position.y - velocidad * Time.deltaTime, gate1.transform.position.z);
          if(gate1.transform.position.y <= tresholdHeight) //Move to Contact
            gate1.transform.position = new Vector3(gate1.transform.position.x, tresholdHeight, gate1.transform.position.z);
        }
        if(gate2.transform.position.y > tresholdHeight){ //Move Gate2
          gate2.transform.position = new Vector3(gate2.transform.position.x, gate2.transform.position.y - velocidad * Time.deltaTime, gate2.transform.position.z);
          if(gate2.transform.position.y <= tresholdHeight) //Move to Contact
            gate2.transform.position = new Vector3(gate2.transform.position.x, tresholdHeight, gate2.transform.position.z);
        }
      }
    }

    public void abrirPuerta(){
      Debug.Log("Abro");
      if(!abrir)
        abrir = true;
    }
}
