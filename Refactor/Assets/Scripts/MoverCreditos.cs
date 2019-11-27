using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCreditos : MonoBehaviour
{
    // Start is called before the first frame update
    bool movi;

    [SerializeField]
    GameObject text;
    [SerializeField]
    float velocidad;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!text.activeSelf)
        {
            text.SetActive(true);
        }
        if (text.activeSelf)
        {
            text.transform.Translate(0, Time.deltaTime* velocidad, 0);
        }
    }
}
