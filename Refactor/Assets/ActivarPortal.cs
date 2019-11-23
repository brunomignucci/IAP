using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPortal : MonoBehaviour
{
    public bool activado;

    // Start is called before the first frame update
    void Start()
    {
        activado = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other){
      if(!activado)
        activado = true;
        Debug.Log("YAESTA");
    }

}
