using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCreditos : MonoBehaviour
{
    // Start is called before the first frame update
    bool movi;
    [SerializeField]
    float velocidad;
    void Start()
    {
        movi = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movi)
        {
            movi = true;
        }
        if (movi)
        {
            this.transform.Translate(0, Time.deltaTime* velocidad, 0);
        }
    }
}
