using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorEscenas : MonoBehaviour
{
	[SerializeField]
	string sceneName, triggerTag;
    bool cargue;
    // Start is called before the first frame update
    void Start()
    {
        cargue = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == triggerTag)
		{
            if (!cargue) {
                cargue = true;
                GameObject.Find("ManejadorEscenas").GetComponent<ManejadorEscenas>().CargarEscena(sceneName, this.gameObject);
                this.transform.Rotate(0, 180, 0);
            }
			
		}
	}
}
