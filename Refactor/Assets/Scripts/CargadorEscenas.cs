using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorEscenas : MonoBehaviour
{
	[SerializeField]
	string sceneName, triggerTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == triggerTag)
		{
			GameObject.Find("ManejadorEscenas").GetComponent<ManejadorEscenas>().CargarEscena(sceneName, this.gameObject);
		}
	}
}
