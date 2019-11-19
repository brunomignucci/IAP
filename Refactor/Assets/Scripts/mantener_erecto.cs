using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mantener_erecto : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 dir;
    Quaternion rot;
    [SerializeField]
    GameObject go;
    void Start()
    {
        dir = go.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        go.transform.forward = dir;
    }
}
