using UnityEngine;
using System.Collections;

public class LogController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            Destroy(gameObject);
            collider.gameObject.GetComponent<PlayerController>().hasLog = true;
        }
    }
}
