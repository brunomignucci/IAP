using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class crear_objetos : NetworkBehaviour
{
    public GameObject indice_izq, gordo_izq, gordo_der, menu_flag, referencia_posicion;
    private GameObject[] cubos;
    private GameObject[] esferas;
	public GameObject cubo, esfera;


    static bool no_cree, escala;
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
		//if (isServer)
		//{
			Vector3 pos_indice_der1 = this.transform.position;
			Vector3 pos_indice_izq1 = indice_izq.transform.position;

			float distancia_entre_indices = (pos_indice_der1 - pos_indice_izq1).magnitude;
			//Debug.Log(distancia_entre_indices);
			if (distancia_entre_indices < 0.03)
			{
				Debug.Log("toque indice izq");
				if (no_cree)
				{
					if (!menu_flag.activeSelf)
					{
						no_cree = false;
						referencia_cubos++;
						Debug.Log("creo el cubo" + referencia_cubos);

						cubos[referencia_cubos] = Instantiate(cubo);
						NetworkServer.Spawn(cubos[referencia_cubos]);
						cubos[referencia_cubos].transform.position = referencia_posicion.transform.position;
					}
					else
					{
						Debug.Log("creo la esfera" + referencia_cubos);
						no_cree = false;
						referencia_esferas++;
						esferas[referencia_esferas] = Instantiate(esfera);
						NetworkServer.Spawn(esferas[referencia_esferas]);
						esferas[referencia_esferas].transform.position = referencia_posicion.transform.position;
					}
				}
			}

			Vector3 pos_gordo_izq1 = gordo_izq.transform.position;
			float distancia_gordoizq_indiceder = (pos_indice_der1 - pos_gordo_izq1).magnitude;
			if (!no_cree && distancia_gordoizq_indiceder < 0.03)
			{
				escala = true;
				Debug.Log("toque el gordo izq");
			}

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
				float distancia = (pos_gordo_izq - pos_indice_der).magnitude * 3;
				float distancia_gordoder = (pos_indice_der - pos_gordo_der).magnitude;
				if (distancia_gordoder == 0)
					Debug.Log("La dist es 0");
				if (distancia_gordoder < 0)
					distancia_gordoder = distancia_gordoder * -1;

				Vector3 newScale = new Vector3(distancia, distancia, distancia);

				if (!menu_flag.activeSelf)
				{

					//Get the NetworkIdentity assigned to the object
					NetworkInstanceId id = cubos[referencia_cubos].GetComponent<NetworkIdentity>().netId;
					cubos[referencia_cubos].transform.localScale = newScale;
					GameObject cubito = cubos[referencia_cubos];
					cubos[referencia_cubos].GetComponent<SpawnableObject>().ScaleObject(distancia);
					//RpcEscalar(id, distancia);

					//NetworkServer.UnSpawn(cubos[referencia_cubos]);
					//cubos[referencia_cubos].transform.localScale = newScale;
					//NetworkServer.Spawn(cubos[referencia_cubos]);
					//cubos[referencia_cubos].transform.position = referencia_posicion.transform.position;// + new Vector3(0, -5f, 90f)

				}
				else
				{
					//get the networkidentity assigned to the object
					NetworkInstanceId id = esferas[referencia_esferas].GetComponent<NetworkIdentity>().netId;
					esferas[referencia_esferas].transform.localScale = newScale;
					esferas[referencia_esferas].GetComponent<SpawnableObject>().ScaleObject(distancia);
					//RpcEscalar(id, distancia);

					//NetworkServer.UnSpawn(esferas[referencia_esferas]);
					//esferas[referencia_esferas].transform.localScale = newScale;
					//NetworkServer.Spawn(esferas[referencia_esferas]);				
					//esferas[referencia_esferas].transform.position = referencia_posicion.transform.position;// + new Vector3(0, -5f, 90f)
				}

				if (distancia_gordoder < 0.03 && !no_cree)
				{
					if (!menu_flag.activeSelf)
					{
						//cubos[referencia_cubos].AddComponent<Rigidbody>();
                        cubos[referencia_cubos].GetComponent<Rigidbody>().isKinematic = false;
                        cubos[referencia_cubos].GetComponent<gravityPrefab>().enabled = true;
                }
					else
					{
                        esferas[referencia_esferas].GetComponent<Rigidbody>().isKinematic = false;
                        esferas[referencia_esferas].GetComponent<gravityPrefab>().enabled = true;
                }
					Debug.Log("toque el gordo der");
					escala = false;
					no_cree = true;
				}
			}
		//}


    }

    IEnumerable<WaitForSeconds> wait_for(float t)
    {
        yield return new WaitForSeconds(t);
    }

	[ClientRpc]
	void RpcEscalar(NetworkInstanceId referencia, float newDistancia)
	{


		//Debug.Log("Cliente: referencia=" + referencia + ". newDistancia=" + newDistancia);
		//ClientScene.FindLocalObject(referencia).transform.localScale = new Vector3(newDistancia,newDistancia,newDistancia);
		

	}






}
