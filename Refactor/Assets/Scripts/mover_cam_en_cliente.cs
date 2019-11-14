using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class mover_cam_en_cliente : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject referencia_cams;
    public GameObject cam_cliente;
    Transform rc;
    Vector3 posicion,pos_izq,pos_der;
    Quaternion rotacion, rot_izq,rot_der;

    void Start()
    {
        rc = referencia_cams.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isServer) 
        {
            updateCam();
        }

    }

    public void updateCam() 
    {
        posicion = rc.position;
        rotacion = rc.rotation;
        pos_izq = rc.GetChild(0).position;
        rot_izq = rc.GetChild(0).rotation;
        pos_der = rc.GetChild(1).position;
        rot_der = rc.GetChild(1).rotation;
        RpcUpdateCam(posicion, rotacion, pos_der, rot_der, pos_izq, rot_izq);
    }

    [ClientRpc]
    void RpcUpdateCam(Vector3 p, Quaternion r, Vector3 pd, Quaternion rd, Vector3 pi, Quaternion ri)
    {
        cam_cliente.transform.position = p;
        cam_cliente.transform.rotation = r;
        cam_cliente.transform.GetChild(0).position = pi;
        cam_cliente.transform.GetChild(0).rotation = ri;
        cam_cliente.transform.GetChild(1).position = pd;
        cam_cliente.transform.GetChild(1).rotation = rd;
    }
}
