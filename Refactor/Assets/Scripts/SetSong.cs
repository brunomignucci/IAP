using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSong : MonoBehaviour
{   private bool activado;
    public AudioClip cancion;
    private bool personajeEncontrado;
    private AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        activado = false;
        personajeEncontrado = false;

    }

    // Update is called once per frame
    void Update()
    {
      if(!personajeEncontrado){
        manager = GameObject.Find("Audio").GetComponent<AudioManager>();
        if(manager != null){
          personajeEncontrado = true;
        }
      }
    }

    void OnTriggerEnter(Collider other){
      if(!activado){
        activado = true;
        manager.setNewSong(cancion);
        Debug.Log("Cambio cancion");
      }
    }
}
