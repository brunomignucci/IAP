using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPiedras : MonoBehaviour
{
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    void OnTriggerEnter(Collider other){
     Debug.Log("Se activa el puzzle de las piedras");
     if(!activated)
       activated = true;
   }


}
