using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;
    private AudioClip otherClip;
    private float FadeTime = 2f;
    private float startVolume;
    private bool cambiar = false;
    private bool apagado = false;
    private bool subir = false;
    // Start is called before the first frame update
    void  Start()
    {
      startVolume = audioSource.volume;
      audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
      //Debug.Log("Tengo Update");
      changeSong(otherClip);
    }

    public void setNewSong(AudioClip newSong){
      otherClip = newSong;
      cambiar = true;
    }

    public void changeSong(AudioClip newSong){
      if(cambiar){
        //Debug.Log("Bajo el volumen");
        if(!subir){
        audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
        if(audioSource.volume <= 0f){
          //Debug.Log("Entre a apagar, una sola vez");
          audioSource.clip = otherClip;
          subir = true;
        }
      }
        if(subir){
         // Debug.Log("Entre a subir");
          audioSource.volume += startVolume * Time.deltaTime / FadeTime;
          if(audioSource.volume >= startVolume){
           // Debug.Log("Pongo a reproducri, una sola vez");
            audioSource.Play();
            subir = false;
            cambiar = false;
          }
        }
      }

    }
}
