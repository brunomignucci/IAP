using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGates : MonoBehaviour
{
  public GameObject gate1,gate2;
  private bool active;
  private float velocidad;
  private float tresholdHeight;
  private float tresholdHeight2;
  private bool arriba;
  private bool termine;
  private Ray ray;
  private Vector3 Origin;
  private float DistanceBetweenRays;
    // Start is called before the first frame update
    void Start()
    {
      termine = false;
      arriba = true;
      active = false;
      velocidad = 2f;
      tresholdHeight = -2f;
      tresholdHeight2 = -15f;
    }

    // Update is called once per frame
    void Update()
    {
      Origin = new Vector3 (transform.position.x,transform.position.y,GetComponent<Collider>().bounds.min.z + 0.015f);
      DistanceBetweenRays = (GetComponent<Collider>().bounds.size.z - 2 * 0.015f) / (10 - 1);
      for(int i=0; i< 10; i++){
        Debug.DrawRay (Origin, Vector3.up , Color.yellow);
        if(Physics.Raycast(Origin,Vector3.up,10))
          active = true;
        else{
          Origin += new Vector3 (0, 0, DistanceBetweenRays);
        }
      }

      if(active && !termine){
        if(arriba){
          moverArriba();
        }
        else{
          moverAbajo();
        }

      }
    }

    public void moverArriba(){
      if(gate1.transform.position.y < tresholdHeight){ //Move Gate1
        gate1.transform.position = new Vector3(gate1.transform.position.x, gate1.transform.position.y + velocidad * Time.deltaTime, gate1.transform.position.z);
        if(gate1.transform.position.y >= tresholdHeight) //Move to Contact
          gate1.transform.position = new Vector3(gate1.transform.position.x, tresholdHeight, gate1.transform.position.z);
      }
      if(gate2.transform.position.y < tresholdHeight){ //Move Gate2
        gate2.transform.position = new Vector3(gate2.transform.position.x, gate2.transform.position.y + velocidad * Time.deltaTime, gate2.transform.position.z);
        if(gate2.transform.position.y >= tresholdHeight){ //Move to Contact
          gate2.transform.position = new Vector3(gate2.transform.position.x, tresholdHeight, gate2.transform.position.z);
          termine = true;
        }
      }
    }

    public void moverAbajo(){
      if(gate1.transform.position.y > tresholdHeight2){ //Move Gate1
        gate1.transform.position = new Vector3(gate1.transform.position.x, gate1.transform.position.y - velocidad * Time.deltaTime, gate1.transform.position.z);
        if(gate1.transform.position.y <= tresholdHeight2) //Move to Contact
          gate1.transform.position = new Vector3(gate1.transform.position.x, tresholdHeight, gate1.transform.position.z);
      }
      if(gate2.transform.position.y > tresholdHeight2){ //Move Gate2
        gate2.transform.position = new Vector3(gate2.transform.position.x, gate2.transform.position.y - velocidad * Time.deltaTime, gate2.transform.position.z);
        if(gate2.transform.position.y <= tresholdHeight2) //Move to Contact
          gate2.transform.position = new Vector3(gate2.transform.position.x, tresholdHeight, gate2.transform.position.z);
      }
    }

    public void abrirPuerta(){
      arriba = true;
    }

    public void cerrarPuerta(){
      arriba = false;
    }

    //
    // private bool isCollidingY(){
    //   Origin = new Vector3 (GetComponent<Collider>().bounds.min.x + 0.015f,transform.position.y,transform.position.z);
    //   DistanceBetweenRays = (GetComponent<Collider>().bounds.size.x - 2 * 0.015f) / (10 - 1);
    //   for (int i = 0; i<10; i++) {
    //       // Ray to be casted.
    //
    //       //Draw ray on screen to see visually. Remember visual length is not actual length.
    //       //Debug.DrawRay (Origin, Vector3.up, Color.yellow);
    //       // if (Physics.Raycast (origin, Vector3.up, 10)) {
    //       //     return true;
    //       //
    //       Origin += new Vector3 (DistanceBetweenRays, 0, 0);
    //   }
    // return false;
    // }
    // void OnTriggerEnter(Collider other){
    //   Debug.Log("Object Entered the collider");
    //   if(!active)
    //     active = true;
    // }
    //
    // void OnTriggerStay(Collider other){
    //   Debug.Log("Object is within trigger");
    // }
    //
    // void OnTriggerExit(Collider other){
    //   Debug.Log("Object Exited Trigger");
    // }
}
