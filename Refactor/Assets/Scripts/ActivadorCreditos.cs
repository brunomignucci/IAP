using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorCreditos : MonoBehaviour
{
    
    GameObject credits;
    bool encontre;
    // Start is called before the first frame update
    void Start()
    {
        encontre = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DETECTORFINALISIMO" && !encontre) 
        {
            GameObject []  creditooos = GameObject.FindGameObjectsWithTag("CREDITOS");
            if (creditooos.Length > 0)
            {
                credits = creditooos[0];
                credits.transform.GetChild(0).gameObject.SetActive(true);
                encontre = true;
            }
            
        }
    }
}
