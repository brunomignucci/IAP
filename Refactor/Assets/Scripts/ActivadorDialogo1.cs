using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDialogo1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject flag, go;
    private void OnCollisionEnter(Collision collision)
    {
        //if (!flag.activeSelf) 
        //{
        //    go.SetActive(true);
        //}
        go.SetActive(true);
        Debug.Log("entre en un trigger");
    }

    private void OnCollisionExit(Collision collision)
    {
        go.SetActive(false);
    }

    
}
