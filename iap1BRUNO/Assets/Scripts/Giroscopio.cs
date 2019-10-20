using UnityEngine;
 using System.Collections;
 
 public class Giroscopio : MonoBehaviour 
 {
	 public GameObject VRCamera;
    private float posInicialY;
    private float posGiroscopioY;
    private float calibrarPosY;
    private bool seInicioJuego;
 
     void Start () 
     {
         Screen.sleepTimeout = SleepTimeout.NeverSleep;
         Input.gyro.enabled=true;
		 posInicialY= VRCamera.transform.eulerAngles.y;

        posInicialY = 0f;

        posGiroscopioY = 0f;
        calibrarPosY = 0f;
}
     
     
     void Update() 
     {
        #if UNITY_STANDALONE_WIN
        #elif UNITY_EDITOR

        #else
                 rotar();
		                 calibrar();
		                 if (seInicioJuego)
		                 {
			                 Invoke("calibrarY", 10f);
			                 seInicioJuego=false;
		                 }
                
               
        #endif
       
     
     }
	 
	 void rotar()
	 {
		VRCamera.transform.rotation = Input.gyro.attitude;
		VRCamera.transform.Rotate(0f,0f,180f, Space.Self);
		VRCamera.transform.Rotate(90f,180f,180f, Space.World);
		posGiroscopioY= VRCamera.transform.eulerAngles.y;
	 }
	 
	 void calibrarY()
	 {
		 calibrarPosY=posGiroscopioY-posInicialY;
	 }
     
	 void calibrar()
	 {
		 VRCamera.transform.Rotate(0f,-calibrarPosY,0f,Space.World);
	 }
	 
 }