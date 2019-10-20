using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffGravity : MonoBehaviour
{
    public GameObject pinky_right;
    public GameObject pinky_left;
    bool gravity = true;
    
    private Vector3 pos_pinky_izq;
    private Vector3 pos_pinky_der;
    private float distancia;

    // Start is called before the first frame update
    void Start()
    {
      if(Physics.gravity.y < 0.0f){
        print("La gravedad esta prendida");
        gravity = true;
      }
      else{
        print(Physics.gravity.y);
        gravity = false;
      }
    }

    // Update is called once per frame
    void Update()
    {
        pos_pinky_der = pinky_right.transform.position;
        pos_pinky_izq = pinky_left.transform.position;
        distancia = (pos_pinky_der - pos_pinky_izq).magnitude;
        /*
        if (Input.GetKeyDown("space")){
        if(gravity){
          gravity = false;
          
                print("Apague");
                //this.GetComponent<Rigidbody>().useGravity = false;
                Physics.gravity = new Vector3(0.0f, 0.0f, 0.0f);
                this.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(0.5f,2.0f) * 20.0f);
        }
        else{
          gravity = true;
               
                print("Prendí");
                //this.GetComponent<Rigidbody>().useGravity = true; 
                Physics.gravity = new Vector3(0.0f, -9.8f, 0.0f);
            }
      }
      */

      if(distancia<0.03)
       {
            if (gravity)
            {
                

                print("Apague");
                gravity = false;
                //this.GetComponent<Rigidbody>().useGravity = false;
                Physics.gravity = new Vector3(0.0f, 0.0f, 0.0f);
                //this.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(0.5f, 2.0f) * 20.0f);
            }
            else
            {
                gravity = true;

                print("Prendí");
                //this.GetComponent<Rigidbody>().useGravity = true; 
                Physics.gravity = new Vector3(0.0f, -9.8f, 0.0f);
            }



        }



    }
}
