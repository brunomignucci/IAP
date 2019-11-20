using UnityEngine;
using System.Collections;

public class accionar_agarrar : AAccionador
{
    float interactDistance = 0.9f;
    float carryDistance = 0.6f;
    public LayerMask interactLayer;

    private Transform carryObject;
    private bool haveObject;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField]
    Camera camara;
    [SerializeField]
    GameObject dedo1, dedo2, dedo3, dedo4;

    [SerializeField]
    GameObject referencia_picking;

    Mesh mesh; // = GetComponent<MeshFilter>().mesh

    public override void accionar()
    {
        accionar_pick();
    }

    public void accionar_pick() {
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer)) {
            carryObject = hit.transform;
            carryObject.GetComponent<Rigidbody>().useGravity = false;
            haveObject = true;
            //carryObject.position =  dedo4.transform.position;
            carryObject.position = camara.transform.position + new Vector3(0f,0f,0.2f);
            Debug.Log("tengo un objeto");
            if (carryObject.childCount == 1)
            {
                mesh = carryObject.GetChild(0).GetComponent<MeshFilter>().mesh;
            }
            else {
                mesh = carryObject.GetComponent<MeshFilter>().mesh;
            }
        }
    }

    void start() {
        
    }

    void Update()
    {
		//Raycast variables.
		//ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);   
		//ray = new Ray(camara.transform.position, camara.transform.forward);
		//ray = new Ray(camara.transform.position, camara.transform.forward);
		ray = new Ray(dedo3.transform.position, dedo4.transform.position - dedo3.transform.position);
		/*
        //Raycasting mechanics.
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            //If we press LMB, it will update the carryObject and its gravity.
            if (Input.GetMouseButtonDown(0))
            {
                carryObject = hit.transform;
                carryObject.GetComponent<Rigidbody>().useGravity = false;
                haveObject = true;
            }
        }*/

		//If we release LMB and we have an object in hand, it will reset the carryObject.
		if ((dedo1.transform.position-dedo2.transform.position).magnitude>0.05f)
        {
            if (haveObject)
            {
                Debug.Log("solteobjeto");
                haveObject = false;
                carryObject.GetComponent<Rigidbody>().useGravity = true;
                carryObject = null;
            }
        }

        //If we have an object in hand, we update its position and smooth it out with basic interpolation.
        if (haveObject)
        {
            //carryObject.position = Vector3.Lerp(carryObject.position, dedo1.transform.position + camara.transform.forward*carryDistance , Time.deltaTime * 8);
            //Vector3 escala_global = new Vector3(carryObject.localScale, Space.World);
            //carryObject.Translate(new Vector3(carryObject.localScale.y / 2f, 0, carryObject.localScale.y / 2f), Space.World);
            if (carryObject.GetComponent<Collider>().tag == "CAJA")
            {
                Debug.Log("agarre la caja");
                carryObject.position = dedo4.transform.position + camara.transform.forward * new Vector3(carryObject.localScale.y / 2f, 0, carryObject.localScale.y*5f).magnitude;
            }
            else 
            {
                carryObject.position = dedo4.transform.position + camara.transform.forward * new Vector3(carryObject.localScale.y / 2f, 0, carryObject.localScale.y).magnitude;
            }
            //carryObject.position = dedo4.transform.position + camara.transform.forward*new Vector3(carryObject.localScale.y / 2f, 0,carryObject.localScale.y).magnitude;// camara.transform.forward * carryObject.transform.localScale.y*carryDistance;
            //carryObject.position = camara.transform.position + new Vector3(0f, 0f, 0.4f);
            //carryObject.position = dedo4.transform.position + new Vector3(mesh.bounds.size.magnitude , 0, mesh.bounds.size.magnitude)*carryDistance;
            //carryObject.position = referencia_picking.transform.position;
            carryObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}