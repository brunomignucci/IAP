using UnityEngine;
using System.Collections;

public class accionador_pick_far : AAccionador
{
    float interactDistance = 9999f;
    float carryDistance = 0.6f;
    public LayerMask interactLayer;

    private Transform carryObject;
    private bool haveObject;
    private Ray ray;
    private RaycastHit hit;
    private Plane plano;
    private Vector3 direction;

    [SerializeField]
    Camera camara;
    [SerializeField]
    GameObject dedo1, dedo2, palm;

    [SerializeField]
    GameObject ref1, ref2, ref3;


    Vector3 curScreenPoint;
    Vector3 curPosition;
    Mesh mesh; // = GetComponent<MeshFilter>().mesh
    Vector3 positionPoint, offset;
    public override void accionar()
    {
        accionar_pick();
        accionar_pick();
    }

    public void accionar_pick()
    {
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            carryObject = hit.transform;
            carryObject.GetComponent<Rigidbody>().useGravity = false;
            haveObject = true;
            positionPoint = camara.WorldToScreenPoint(palm.transform.position);
            offset = palm.transform.position - camara.ScreenToWorldPoint(new Vector3(palm.transform.position.x, palm.transform.position.y, palm.transform.position.z));

        }
    }

    void start()
    {
       
    }

    void Update()
    {
        //Raycast variables.
        //ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);   
        //ray = new Ray(camara.transform.position, camara.transform.forward);
        //ray = new Ray(camara.transform.position, camara.transform.forward);
        plano.Set3Points(ref1.transform.position, ref2.transform.position, ref3.transform.position);
        direction = plano.normal;
        //direction = Quaternion.Euler(0, 90, 0) * direction;

        ray = new Ray(palm.transform.position, direction);
        Debug.DrawRay(palm.transform.position, direction, Color.blue);
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
        }

        //If we release LMB and we have an object in hand, it will reset the carryObject.
        if ((dedo1.transform.position - dedo2.transform.position).magnitude > 0.05f)
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
            curScreenPoint = new Vector3(palm.transform.position.x, palm.transform.position.y, positionPoint.z);
            curPosition = camara.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            carryObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
}