using UnityEngine;
 using System.Collections;

 public class Giroscopio : MonoBehaviour
 {
	 public GameObject VRCamera;
	 private float posInicialY=0f;
   private float posInicialX=0f;
   private float posInicialZ=0f;
	 private float posGiroscopioY=0f;
	 private float calibrarPosY=0f;
	 public bool seInicioJuego  = true;
   private float yActual;
   private float yAntiguo;
   private float posX;
   private float posY;
   Quaternion qPosicion;

     void Start ()
     {
		 Input.gyro.enabled=true;
		 posInicialY= VRCamera.transform.eulerAngles.y;
     posInicialX= VRCamera.transform.eulerAngles.x;
     posInicialZ= VRCamera.transform.eulerAngles.z;
     qPosicion=Input.gyro.attitude;
     yAntiguo=qPosicion.y;
     yActual=0f;
     }


     void Update()
     {
         qPosicion=Input.gyro.attitude;
         yActual=qPosicion.y;
         rotar();
         calibrar();

         //trasladar();
         if(seInicioJuego){
            Invoke("calibrarPosY",3f);
            seInicioJuego = false;
         }
         yAntiguo=yActual;
     }

        void trasladar()
        {
          //VRCamera.transform.traslation= Input.gyro.attitude;

          VRCamera.transform.Translate((yActual-yAntiguo)*10f*Vector3.up,Space.World);
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
