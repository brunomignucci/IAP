using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjCliente : MonoBehaviour
{
    // Start is called before the first frame update
    private bool activado;
    [SerializeField]
    private GameObject obj;
    void Start()
    {
        activado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activado) {
        #if UNITY_ANDROID
            obj.SetActive(true);
            activado = true;
        #endif
        }
    }
}
