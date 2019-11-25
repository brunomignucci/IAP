using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MoverPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject referencia_cams;
    public GameObject cam_cliente;
    Transform rc;
    Vector3 posicion, pos_izq, pos_der;
    Quaternion rotacion, rot_izq, rot_der;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isServer)
        {
           
        }

    }

    public void updateCam()
    {
        
       
    }

    [ClientRpc]
    void RpcUpdateCam(Vector3 p, Quaternion r, Vector3 pd, Quaternion rd, Vector3 pi, Quaternion ri)
    {
        
    }
}
