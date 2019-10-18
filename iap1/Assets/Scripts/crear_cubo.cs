using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crear_cubo : MonoBehaviour
{
    public GameObject indice_izq, gordo_izq,gordo_der,palma_der,middle_der,pinky_der,ring_der;
    public GameObject menu_flag;
    public GameObject referencia_posicion;
    //private GameObject cube;
    private GameObject []  cubos;
    private GameObject [] esferas;
    
    
    static bool no_cree,escala;
    int referencia_cubos, referencia_esferas;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("arranque el script ");
        no_cree = true;
        escala = false;
        cubos = new GameObject[99];
        esferas = new GameObject[99];
        referencia_cubos = 0;
        referencia_esferas = 0;
    }

    void flag_no_cree()
    {
        no_cree = !no_cree;
    }

    // Update is called once per frame
    void Update()
    {
        if (!no_cree) 
        {
            if (!menu_flag.activeSelf)
            {
                cubos[referencia_cubos].transform.position = referencia_posicion.transform.position + new Vector3(0, 0.5f, 0.3f);
            }
            else 
            {
                esferas[referencia_esferas].transform.position = referencia_posicion.transform.position + new Vector3(0, 0.5f, 0.3f);
            }
        }
        if (escala)
        {
            //mientras esté en true voy actualizando la escala del cubo segun la distancia entre el dedo en el que esta este script y el dedo gordo izquierdo
            Vector3 pos_gordo_izq = gordo_izq.transform.position;
            Vector3 pos_indice_der = this.transform.position;
            Vector3 pos_gordo_der = gordo_der.transform.position;
            float distancia = (pos_gordo_izq - pos_indice_der).magnitude*3;
            float distancia_gordoder = (pos_indice_der- pos_gordo_der).magnitude;
            if (distancia_gordoder == 0)
                Debug.Log("La dist es 0");
            if (distancia_gordoder < 0)
                distancia_gordoder = distancia_gordoder * -1;
            if (!menu_flag.activeSelf)
            {
                cubos[referencia_cubos].transform.localScale = new Vector3(distancia, distancia, distancia);
            }
            else
            {
                esferas[referencia_esferas].transform.localScale = new Vector3(distancia, distancia, distancia);
                
            }
           
            if (distancia_gordoder < 0.03 && !no_cree)
            {
                if (!menu_flag.activeSelf)
                {
                    cubos[referencia_cubos].AddComponent<Rigidbody>();
                }
                else
                {
                    esferas[referencia_esferas].AddComponent<Rigidbody>();
                }
                Debug.Log("toque el gordo der");
                escala = false;
                no_cree = true;
            }
        }
        
        
    }

    IEnumerable<WaitForSeconds> wait_for(float t)
    {
        yield return new WaitForSeconds(t);
    }

    void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "GORDO_DER")
        {
            escala = false;
            Debug.Log("toque el gordo der desde el collider");          
            
            
               
        }
        if (other.tag=="INDICE_IZQ")
        {
            Debug.Log("toque indice izq");
           if (no_cree) 
           {                
                if (!menu_flag.activeSelf)
                {
                    no_cree = false;
                    referencia_cubos++;
                    Debug.Log("creo el cubo" + referencia_cubos);
                    cubos[referencia_cubos] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cubos[referencia_cubos].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    //cube.AddComponent<Rigidbody>();
                    cubos[referencia_cubos].transform.position = referencia_posicion.transform.position + new Vector3(0, 0.5f, 0.3f);
                }
                else 
                {
                    no_cree = false;
                    referencia_esferas++;
                    esferas[referencia_esferas] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    esferas[referencia_esferas].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    //cube.AddComponent<Rigidbody>();
                    esferas[referencia_esferas].transform.position = referencia_posicion.transform.position+ new Vector3(0, 0.5f, 0.3f);
                }                
           }            
        }
        if (!no_cree && other.tag == "GORDO_IZQ")
        {
            escala = true;
            Debug.Log("toque el gordo izq");
        }
        
    }

    



    
}
