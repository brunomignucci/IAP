using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leap_player_controller : MonoBehaviour
{
    Vector3 rot_inicial, rot;
    public GameObject palm_r;
    private float movementSpeed;
    private GameObject palma;
    float rot_x,rot_y,rot_z;
	GameObject Reference;

    int pepe = 0;
    bool encontre;
    // Start is called before the first frame update
    void Start()
    {
        //rot_inicial = transform.rotation.eulerAngles;
        movementSpeed = 4.0f;
        encontre = false;
		Reference = GameObject.Find("Leap Rig");
    }

    // Update is called once per frame
    void Update()
    {
        if (!encontre)
        {
            encontre = true;
            //palma = GameObject.Find("6 Palm.000");
            //if (palma != null)
            //    encontre = true;
            //else Debug.Log("No encontre");
        }
        else
        {
			//Debug.Log("estoy en la mano");
			Quaternion worldSpaceRotation = palm_r.transform.rotation;
			//Quaternion localSpaceRotation = Quaternion.Inverse(transform.root.transform.rotation) * worldSpaceRotation;
			Quaternion localSpaceRotation = Quaternion.Inverse(Reference.transform.rotation) * worldSpaceRotation;
			rot = localSpaceRotation.eulerAngles;
			rot_x = rot.x;
            rot_y = rot.y;
            rot_z = rot.z;
            //Debug.Log("la rotacion de x es  " + rot_x);
            //Debug.Log("la rotacion de y es  " + rot_y);
            //Debug.Log("la rotacion de z es  " + rot_z);

            //Vector3 adelante = transform.root.forward;
            Vector3 adelante = Vector3.ProjectOnPlane(transform.root.forward, Vector3.up);
            Vector3 aux = new Vector3(adelante.x,  0, adelante.z);
            Vector3 nueva_pos;

            if ( rot_x>320f && rot_x<360f && rot_y>230f && rot_y<270f && rot_z>305f && rot_z <345f)
            {				
				float delta = Time.deltaTime * movementSpeed;
                GetComponent<Client>().RpcMoverPlayer(delta);
            }
            else      
                if(rot_x > 242f && rot_x < 322f && rot_y > 60f && rot_y < 135f && rot_z > 50 && rot_z < 135f)
                {
				    float delta = - Time.deltaTime * movementSpeed;                    
                    GetComponent<Client>().RpcMoverPlayer(delta);
			}         
        }  
    }
}
