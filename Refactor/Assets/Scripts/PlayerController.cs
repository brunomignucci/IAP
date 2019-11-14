 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour
{

	public GameObject ClientHandRight,ClientHandLeft;
	public GameObject LeapHandRight,LeapHandLeft;
    bool isLeapUser,encontre;
    private GameObject palma_leap;
	public GameObject ServerCamera, ClientCamera;
	public GameObject PadreManosLeap;
    //public GameObject mainCam;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

    }

	
}
