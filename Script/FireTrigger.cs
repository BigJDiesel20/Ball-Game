using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour {
    
    public TriggerFlame Fire;
    public bool isTriggered;
    // Use this for initialization
    void Start () {
        isTriggered = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = true;
        }
    }
}
